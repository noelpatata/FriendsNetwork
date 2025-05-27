namespace FriendsNetwork.Domain.Abstractions.Services.Notifications;

public interface ISaveNotificationService
{
    Task<bool> SaveNotification(long fromUserId, Guid toUser, string message);

}