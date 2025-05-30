using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using FriendsNetwork.Application.Services.Users.Exceptions;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Entities;
using FriendsNetwork.WebSocket.Services;

namespace FriendsNetwork.WebSocket.Managers;

public class WebSocketConnectionManager(
    IServiceProvider serviceProvider
    ) : IWebSocketConnectionManager
{
    private readonly ConcurrentDictionary<long, System.Net.WebSockets.WebSocket> _sockets = new();
    
    public IEnumerable<long> GetAllConnectedUserIds()
    {
        return _sockets.Keys;
    }
    public void AddSocket(long userId, System.Net.WebSockets.WebSocket socket)
    {
        _sockets[userId] = socket;
    }

    public async Task RemoveSocketAsync(long userId)
    {
        if (_sockets.TryRemove(userId, out var socket))
        {
            if (socket.State == WebSocketState.Open || socket.State == WebSocketState.CloseReceived)
            {
                try
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by server", CancellationToken.None);
                }
                catch (WebSocketException)
                {
                    // The connection may already be closed/aborted; ignore
                }
            }
        }
    }


    public async Task SendMessageAsync(long userId, string message)
    {
        if (_sockets.TryGetValue(userId, out var socket) && socket.State == WebSocketState.Open)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
    
    public System.Net.WebSockets.WebSocket? GetSocketByUserId(long userId)
    {
        _sockets.TryGetValue(userId, out var socket);
        return socket;
    }
    
    public bool IsUserConnected(long userId)
    {
        return _sockets.ContainsKey(userId);
    }

    public async Task ReceiveLoopAsync(long userId, System.Net.WebSockets.WebSocket socket)
    {
        var buffer = new byte[1024 * 4];

        try
        {
            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.CloseStatus.HasValue)
                {
                    await RemoveSocketAsync(userId);
                    break;
                }

                var messageJson = Encoding.UTF8.GetString(buffer, 0, result.Count);
                var messageData = JsonSerializer.Deserialize<Message>(messageJson);
                if (messageData == null)
                    break;
                messageData.senderId = userId; 

                

                using var scope = serviceProvider.CreateScope();
                var dispatcher = scope.ServiceProvider.GetRequiredService<IMessageDispatcherService>();
                await dispatcher.DispatchAsync(messageData);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"WebSocket receive error for user {userId}: {ex}");
        }
    }
}