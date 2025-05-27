using FriendsNetwork.Application.Services.FriendRequests.Exceptions;
using FriendsNetwork.Application.Services.Users.Exceptions;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Notifications;

namespace FriendsNetwork.Application.Services.Notifications;

public class SaveNotificationService(
INotificationRepository notification,
IUserRepository userRepository) : ISaveNotificationService
{
    public async Task<bool> SaveNotification(long fromUserId, Guid toUser, string message)
    {
        var friendUser = await userRepository.GetByOnlineId(toUser);
        if (friendUser == null)
            throw new UserNotFoundException();

        if (fromUserId == friendUser.id)
            throw new CannotAcceptYourSelfException();
        
        return await notification.SaveNotification(fromUserId, friendUser.id, message);
    }
}
