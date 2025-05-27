namespace FriendsNetwork.Domain.Abstractions.Services.Notifications;

public interface IMarkAsDeliveredService
{
    Task<bool> MarkNotificationAsDelivered(long notificationId);
}