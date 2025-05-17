using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Friendships;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.Friendships
{
    public class GetFriendshipsService : IGetFriendShipsService
    {

        private readonly IFriendshipRepository _friendShipRepository;
        public GetFriendshipsService(IFriendshipRepository friendShipRepository)
        {
            _friendShipRepository = friendShipRepository;
        }
        public Task<IEnumerable<FriendShip?>?> GetFriendShipsServiceAsync(long? userId)
        {
            return _friendShipRepository.GetAll(userId);
        }
    }
}
