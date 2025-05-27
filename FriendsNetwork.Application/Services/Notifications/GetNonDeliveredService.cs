using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Notifications;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.Notifications;

public class GetNonDeliveredService(
INotificationRepository notification) : IGetNonDeliveredService
{

    public Task<IEnumerable<Notification>> GetNonDeliveredNotifications(long userId)
    {
        return notification.GetNonDeliveredNotifications(userId);
    }
}