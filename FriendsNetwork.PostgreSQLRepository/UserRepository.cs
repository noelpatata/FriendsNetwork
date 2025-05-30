using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FriendsNetwork.PosgreSqlRepository
{
    public class UserRepository(FriendsNetworkDbContext context) : IUserRepository
    {
        public async Task<User> Add(User user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User?>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User?> GetByOnlineId(Guid onlineId)
        {
            return await context.Users.Where(x=>x.online_id == onlineId).FirstOrDefaultAsync();
        }

        public async Task<User?> GetById(long id)
        {
            return await context.Users.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await context.Users.Where(x => x.username.Equals(username)).FirstOrDefaultAsync();
        }
    }
}
