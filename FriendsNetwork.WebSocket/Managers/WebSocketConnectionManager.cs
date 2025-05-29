using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace FriendsNetwork.WebSocket.Managers;

public class WebSocketConnectionManager : IWebSocketConnectionManager
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
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by server", CancellationToken.None);
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
        while (socket.State == WebSocketState.Open)
        {
            var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            if (result.CloseStatus.HasValue)
            {
                await RemoveSocketAsync(userId);
                break;
            }

            // (Optional) Handle incoming message
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            Console.WriteLine($"Received from user {userId}: {message}");
        }
    }
}