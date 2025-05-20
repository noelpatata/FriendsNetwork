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
        public async Task<FriendShip> GetFriendShip(long user1Id, long user2Id)
        {
            return await _context.Friendships.Where(x => x.user_id == user1Id && x.friend_id == user2Id)
                    .Include(x => x.Friend)
                    .FirstOrDefaultAsync();
        }
        public async Task<bool> Delete(Friendship friend1, Friendship friend2)
        {
            try
            {

                _context.RemoveRange([friend1, friend2]);

                await _context.SaveChangesAsync();

                return true;
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
