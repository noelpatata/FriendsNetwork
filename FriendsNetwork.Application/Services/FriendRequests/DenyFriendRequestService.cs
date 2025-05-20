using FriendsNetwork.Application.Services.Users.Exceptions;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests.Exceptions;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.FriendRequests
{
    public class DenyFriendRequestService(
        IFriendRequestRepository repo,
        IUserRepository userRepository) : IDenyFriendRequestService
    {
        private readonly IFriendRequestRepository _friendRequestRepository = repo;
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<FriendRequest> DenyFriendRequestAsync(long userId, Guid friendOnlineId)
        {
            //fetch user by online id
            var friendUser = await _userRepository.GetByOnlineId(friendOnlineId);
            if (friendUser == null)
                throw new UserNotFoundException();

            //fetch received friend request
            var friendRequest = await _friendRequestRepository.GetReceivedFriendRequestFromUser(userId, friendUser.id);
            if (friendRequest == null)
                throw new FriendRequestsNotFoundException();

            //delete
            await _friendRequestRepository.DenyFriendRequest(friendRequest);
            return friendRequest;
        }
    }
}
