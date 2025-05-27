using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Notifications;

namespace FriendsNetwork.Application.Services.Notifications;

public class MarkAsDeliveredService(INotificationRepository notification): IMarkAsDeliveredService
{
    public Task<bool> MarkNotificationAsDelivered(long notificationId)
    {
        return notification.MarkNotificationAsDelivered(notificationId);
    }
}