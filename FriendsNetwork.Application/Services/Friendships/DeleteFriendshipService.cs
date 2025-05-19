using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Friendships;

namespace FriendsNetwork.Application.Services.Friendships
{
    public class DeleteFriendshipService(IFriendshipRepository friendShipRepository) : IDeleteFriendshipService
    {
        private readonly IFriendshipRepository _friendShipRepository = friendShipRepository;

        public Task<bool> DeleteFriendShipServiceAsync(long? userId, Guid? friendOnlineId)
        {
            return _friendShipRepository.Delete(userId, friendOnlineId);
        }
    }
}
