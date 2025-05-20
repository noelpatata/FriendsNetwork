using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Repositories
{
    public interface IFriendshipRepository
    {
        Task<bool> Delete(IEnumerable<Friendship> friendship);
        Task<IEnumerable<Friendship?>?> GetAll(long userId);

        Task<IEnumerable<Friendship>> GetFriendShip(long user1Id, long user2Id);
        Task<bool> AddFriendship(long user1, long user2);
        Task<bool> AlreadyFriends(long user1, long user2);
    }
}
