using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using FriendsNetwork.Application.Services.Users.Exceptions;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Entities;
using FriendsNetwork.WebSocket.Managers;

namespace FriendsNetwork.WebSocket.Dispatchers;

public class MessageService(
    IServiceProvider serviceProvider,
    IWebSocketConnectionManager connectionManager) : IWebSocketMessageDispatcher
{

    public async Task DispatchAsync(Message message)
    {
        using var scope = serviceProvider.CreateScope();
        var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
        var notificationRepo = scope.ServiceProvider.GetRequiredService<INotificationRepository>();

        var receiverUser = await userRepo.GetByOnlineId(message.receiverOnlineId);
        if (receiverUser == null)
            return;
        
        var sender = await userRepo.GetById(message.senderId);
        if (sender == null)
            return;
        var socket = connectionManager.GetSocketByUserId(receiverUser.id);
        if (socket == null || socket.State != WebSocketState.Open)
        {
            await notificationRepo.SaveNotification(sender.id, receiverUser.id, message.message);
        }
        else
        {
            var payload = JsonSerializer.Serialize(new
            {
                type = "message",
                fromUsername = sender.username,
                message = message.message
            });

            await socket.SendAsync(
                new ArraySegment<byte>(Encoding.UTF8.GetBytes(payload)),
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
        }
    }
}