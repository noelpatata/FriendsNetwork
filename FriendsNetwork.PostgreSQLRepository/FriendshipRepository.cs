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
        public async Task<IEnumerable<Friendship>> GetFriendShip(long user1Id, long user2Id)
        {
            return await _context.Friendships.Where(x => (x.user_id == user1Id && x.friend_id == user2Id) || (x.user_id == user2Id && x.friend_id == user1Id)).ToListAsync();
        }
        public async Task<bool> Delete(IEnumerable<Friendship> friendship)
        {
            try
            {

                _context.RemoveRange(friendship);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Friendship?>?> GetAll(long userId)
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

        public async Task<bool> AddFriendship(long userId, long frienduserId)
        {
            try
            {
                //add friend relationship (both ways)
                var newFriend1 = new Friendship
                {
                    user_id = userId,
                    friend_id = frienduserId
                };

                var newFriend2 = new Friendship
                {
                    user_id = frienduserId,
                    friend_id = userId
                };

                await _context.Friendships.AddRangeAsync([newFriend1, newFriend2]);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AlreadyFriends(long user1, long user2)
        {
            var alreadyFriends = await _context.Friendships.Where(x => (x.user_id == user1 && x.friend_id == user2) || (x.user_id == user2 && x.friend_id == user1)).FirstOrDefaultAsync();
            return alreadyFriends != null;
        }
    }
}
