
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Services.Friendships
{
    public interface IGetFriendShipsService
    {
        Task<IEnumerable<FriendShip?>?> GetFriendShipsServiceAsync(long? userId);

    }
}
