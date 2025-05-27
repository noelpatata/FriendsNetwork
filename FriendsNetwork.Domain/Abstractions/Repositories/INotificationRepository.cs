using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Repositories;

public interface INotificationRepository
{
    Task<bool> SaveNotification(long fromUserId, long toUserId, string message);
    Task<IEnumerable<Notification>> GetNonDeliveredNotifications(long userId);
    Task<bool> MarkNotificationAsDelivered(long notificationId);
}