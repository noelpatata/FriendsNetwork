using FriendsNetwork.Application.Services.Users.Exceptions;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Services.Friendships.Exceptions;
using FriendsNetwork.Domain.Abstractions.Services.Notifications;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.FriendRequests
{
    public class SendFriendRequestService (
        IFriendRequestRepository repo,
        IFriendshipRepository repoFriends,
        IUserRepository repoUser,
        ISaveNotificationService notificationService) : ISendFriendRequestService
    {
        public async Task<FriendRequest> SendFriendRequestAsync(long userId, Guid friendOnlineId)
        {
            //needed fetch
            var friendUser = await repoUser.GetByOnlineId(friendOnlineId);
            if (friendUser == null)
                throw new UserNotFoundException();

            //check if already friends
            var alreadyFriends = await repoFriends.AlreadyFriends(userId, friendUser.id);
            if (alreadyFriends)
                throw new AlreadyFriendsException();

            //remove previous friend requests
            await repo.DeleteFriendRequests(userId, friendUser.id);

            //send friend request
            var response = await repo.SendFriendRequest(userId, friendUser.id, friendUser);
            
            //save notification
            await notificationService.SaveNotification(userId, friendOnlineId, "You have a new friend request");
            
            return response;
        }
    }
}
