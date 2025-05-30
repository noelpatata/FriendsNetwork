using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.WebSocket.Managers;

namespace FriendsNetwork.WebSocket.Services;

public class NotificationDispatcherService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IWebSocketConnectionManager _connectionManager;

    public NotificationDispatcherService(IServiceProvider serviceProvider, IWebSocketConnectionManager connectionManager)
    {
        _serviceProvider = serviceProvider;
        _connectionManager = connectionManager;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var notificationRepo = scope.ServiceProvider.GetRequiredService<INotificationRepository>();

            // Get all connected userIds
            var connectedUserIds = _connectionManager.GetAllConnectedUserIds();

            foreach (var userId in connectedUserIds)
            {
                var notifications = await notificationRepo.GetNonDeliveredNotifications(userId);

                foreach (var n in notifications)
                {
                    var socket = _connectionManager.GetSocketByUserId(userId);
                    if (socket == null || socket.State != WebSocketState.Open)
                        continue;
                    
                    var payload = JsonSerializer.Serialize(new
                    {
                        type = "notification",
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
