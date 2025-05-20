using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Repositories
{
    public interface IFriendshipRepository
    {
        Task<bool> Delete(Friendship friend1, Friendship friend2);
        Task<IEnumerable<Friendship?>?> GetAll(long? userId);

        Task<FriendShip> GetFriendShip(long user1Id, long user2Id);
        Task<bool> DeleteFriendShip(long user1Id, long user2Id);
    }
}
