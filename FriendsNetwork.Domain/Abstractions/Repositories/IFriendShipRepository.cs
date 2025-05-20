using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Repositories
{
    public interface IFriendshipRepository
    {
        Task<IEnumerable<Friendship?>?> GetAll(long? userId);

        Task<bool> Delete(long userId, Guid friendOnlineId);

        Task<FriendShip?> GetFriendShip(long user1Id, long user2Id);
        Task<bool> DeleteFriendShip(long user1Id, long user2Id);
    }
}
