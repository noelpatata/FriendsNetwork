using FriendsNetwork.Application.Services.Users.Exceptions;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Friendships.Exceptions;
using FriendsNetwork.Domain.Entities;
using FriendsNetwork.SqlRepository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FriendsNetwork.PosgreSqlRepository
{
    public class FriendshipRepository (FriendsNetworkDbContext context): IFriendshipRepository
    {
        private readonly FriendsNetworkDbContext _context = context;
        public async Task<bool> Delete(long? userId, Guid? friendOnlineId)
        {
            try
            {
                var friendUser = await _context.Users.Where(u => u.online_id == friendOnlineId).FirstOrDefaultAsync();

                if (friendUser == null)
                    throw new UserNotFoundException();

                var friendlog = await _context.Friendships.Where(x => x.user_id == userId && x.friend_id == friendUser.id)
                    .Include(x => x.Friend)
                    .FirstOrDefaultAsync();

                var friendlog1 = await _context.Friendships.Where(x => x.user_id == friendUser.id && x.friend_id == userId)
                    .FirstOrDefaultAsync();

                if (friendlog == null)
                    throw new FriendNotFoundException();

                if (friendlog1 == null)
                    throw new FriendNotFoundException();

                _context.RemoveRange([friendlog, friendlog1]);

                await RemoveExistingRequestsBetween(userId, friendUser.id);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task RemoveExistingRequestsBetween(long? userA, long? userB)
        {
            try
            {
                var requests = await _context.FriendRequests
                .Where(fr =>
                    (fr.sender_id == userA && fr.receiver_id == userB) ||
                    (fr.sender_id == userB && fr.receiver_id == userA))
                .ToListAsync();

                _context.FriendRequests.RemoveRange(requests);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<Friendship?>?> GetAll(long? userId)
        {
            try
            {
                return await _context.Friendships.Where(x => x.user_id == userId)
                        .Include(x => x.Friend)
                        .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
