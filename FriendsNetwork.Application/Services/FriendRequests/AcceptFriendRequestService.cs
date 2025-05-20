using FriendsNetwork.Application.Services.FriendRequests.Exceptions;
using FriendsNetwork.Application.Services.Users.Exceptions;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests.Exceptions;
using FriendsNetwork.Domain.Abstractions.Services.Friendships.Exceptions;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.FriendRequests
{
    public class AcceptFriendRequestService (
        IFriendshipRepository friendShipRepository,
        IFriendRequestRepository repo,
        IUserRepository userRepository) : IAcceptFriendRequestService
    {
        private readonly IFriendshipRepository _friendShipRepository = friendShipRepository;
        private readonly IFriendRequestRepository _friendRequestRepository = repo;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<FriendRequest> AcceptFriendRequestAsync(long userId, Guid friendOnlineId)
        {

            //fetch user by online id
            var friendUser = await _userRepository.GetByOnlineId(friendOnlineId);
            if (friendUser == null)
                throw new UserNotFoundException();

            if (userId == friendUser.id)
                throw new CannotAcceptYourSelfException();

            //check if already friends
            var alreadyFriends = await _friendShipRepository.AlreadyFriends(userId, friendUser.id);
            if (alreadyFriends)
                throw new AlreadyFriendsException();

            //fetch received friend request
            var friendRequest = await _friendRequestRepository.GetReceivedFriendRequestFromUser(userId, friendUser.id);
            if (friendRequest == null)
                throw new FriendRequestsNotFoundException();

            //mark friend request as accepted
            await _friendRequestRepository.AcceptFriendRequest(friendRequest);

            //create friendship
            await _friendShipRepository.AddFriendship(userId, friendUser.id);

            return friendRequest;
        }
    }
}
