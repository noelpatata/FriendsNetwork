using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Friendships;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.Friendships
{
    public class GetFriendshipsService(IFriendshipRepository friendShipRepository) : IGetFriendShipsService
    {

        private readonly IFriendshipRepository _friendShipRepository = friendShipRepository;
        public Task<IEnumerable<Friendship?>?> GetFriendShipsServiceAsync(long userId)
        {
            return _friendShipRepository.GetAll(userId);
        }
    }
}
