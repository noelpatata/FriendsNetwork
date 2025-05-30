using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using FriendsNetwork.Application.Services.Users.Exceptions;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.WebSocket.Managers;

namespace FriendsNetwork.WebSocket.Services;

public class NotificationDispatcherService(
    IServiceProvider serviceProvider,
    IWebSocketConnectionManager connectionManager)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = serviceProvider.CreateScope();
            var notificationRepo = scope.ServiceProvider.GetRequiredService<INotificationRepository>();
            var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();

            // Get all connected userIds
            var connectedUserIds = connectionManager.GetAllConnectedUserIds();

            foreach (var userId in connectedUserIds)
            {
                var notifications = await notificationRepo.GetNonDeliveredNotifications(userId);

                foreach (var n in notifications)
                {
                    var socket = connectionManager.GetSocketByUserId(userId);
                    if (socket == null || socket.State != WebSocketState.Open)
                        continue;

                    var user = await userRepo.GetById(n.fromUserId);
                    if (user == null)
                        continue;
                    
                    var payload = JsonSerializer.Serialize(new
                    {
                        type = "notification",
                        fromUsername = user.username,
                        message = n.message
                    });

                    await socket.SendAsync(
                        new ArraySegment<byte>(Encoding.UTF8.GetBytes(payload)),
                        WebSocketMessageType.Text,
                        true,
                        stoppingToken);

                    await notificationRepo.MarkNotificationAsDelivered(n.id);
                }
            }

            await Task.Delay(2000, stoppingToken);
        }
    }

}
