
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Services.Friendships
{
    public interface IGetFriendShipsService
    {
        Task<IEnumerable<Friendship?>?> GetFriendShipsServiceAsync(long? userId);

    }
}
