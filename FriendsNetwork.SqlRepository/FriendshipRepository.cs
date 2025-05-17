using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Entities;
using FriendsNetwork.SqlRepository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FriendsNetwork.PosgreSqlRepository
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly FriendsDbContext _context;
        public FriendshipRepository(FriendsDbContext context)
        {
            _context = context;
        }
        public Task<bool> Delete(long? userId, Guid? friendOnlineId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FriendShip?>?> GetAll(long? userId)
        {
            return await _context.Friendships.Where(x => x.user_id == userId)
                    .Include(x => x.Friend)
                    .ToListAsync();
        }
    }
}
