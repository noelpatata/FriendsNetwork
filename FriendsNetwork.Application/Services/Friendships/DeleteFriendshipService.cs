using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Friendships;

namespace FriendsNetwork.Application.Services.Friendships
{
    public class DeleteFriendshipService : IDeleteFriendShipService
    {
        private readonly IFriendShipRepository _friendShipRepository;
        public DeleteFriendshipService(IFriendShipRepository friendShipRepository)
        {
            _friendShipRepository = friendShipRepository;
        }

        public Task<bool> DeleteFriendShipServiceAsync(long? userId, Guid? friendOnlineId)
        {
            return _friendShipRepository.Delete(userId, friendOnlineId);
        }
    }
}
