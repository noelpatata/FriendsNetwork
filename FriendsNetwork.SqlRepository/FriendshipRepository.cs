using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.PosgreSqlRepository
{
    public class FriendshipRepository : IFriendShipRepository
    {
        public Task<bool> Delete(long? userId, Guid? friendOnlineId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FriendShip?>?> GetAll(long? userId)
        {
            throw new NotImplementedException();
        }
    }
}
