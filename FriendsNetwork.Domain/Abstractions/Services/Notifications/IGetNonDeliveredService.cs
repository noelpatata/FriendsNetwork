using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Services.Notifications;

public interface IGetNonDeliveredService
{
    Task<IEnumerable<Notification>> GetNonDeliveredNotifications(long userId);
}