using FriendsNetwork.Application.Services.Users.Exceptions;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Services.Friendships.Exceptions;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.FriendRequests
{
    public class SendFriendRequestService (
        IFriendRequestRepository repo,
        IFriendshipRepository repoFriends,
        IUserRepository repoUser) : ISendFriendRequestService
    {
        private readonly IFriendRequestRepository _friendRequestRepository = repo;
        private readonly IFriendshipRepository _repoFriends = repoFriends;
        private readonly IUserRepository _repoUser = repoUser;
        public async Task<FriendRequest> SendFriendRequestAsync(long userId, Guid friendOnlineId)
        {
            //needed fetch
            var friendUser = await _repoUser.GetByOnlineId(friendOnlineId);
            if (friendUser == null)
                throw new UserNotFoundException();

            //check if already friends
            var alreadyFriends = await _repoFriends.AlreadyFriends(userId, friendUser.id);
            if (alreadyFriends)
                throw new AlreadyFriendsException();

            //remove previous friend requests
            await _friendRequestRepository.DeleteFriendRequests(userId, friendUser.id);

            //send friend request
            return await _friendRequestRepository.SendFriendRequest(userId, friendUser.id, friendUser);
        }
    }
}
