using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Repositories
{
    public interface IFriendshipRepository
    {
        Task<IEnumerable<Friendship?>?> GetAll(long? userId);

        Task<bool> Delete(long? userId, Guid? friendOnlineId);
    }
}
