using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Repositories
{
    public interface IFriendShipRepository
    {
        Task<IEnumerable<FriendShip?>?> GetAll(long? userId);

        Task<bool> Delete(long? userId, Guid? friendOnlineId);
    }
}
