using FriendsNetwork.Application.Services.Users.Exceptions;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Friendships;

namespace FriendsNetwork.Application.Services.Friendships
{
    public class DeleteFriendshipService(
        IFriendshipRepository friendShipRepository,
        IFriendRequestRepository friendRequestsRepository,
        IUserRepository userRepository) : IDeleteFriendshipService
    {
        private readonly IFriendshipRepository _friendShipRepository = friendShipRepository;
        private readonly IFriendRequestRepository _friendRequestsRepository = friendRequestsRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> DeleteFriendShipServiceAsync(long userId, Guid friendOnlineId)
        {
            //fetch user by online id
            var friendUser = await _userRepository.GetByOnlineId(friendOnlineId);
            if (friendUser == null)
                throw new UserNotFoundException();

            //delete friend requests
            await _friendRequestsRepository.DeleteFriendRequests(userId, friendUser.id);

            //delete friendship both ways
            var friendShip = await _friendShipRepository.GetFriendShip(userId, friendUser.id);
            return await _friendShipRepository.Delete(friendShip);
        }
    }
}
