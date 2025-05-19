using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Entities;
using FriendsNetwork.SqlRepository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FriendsNetwork.PosgreSqlRepository
{
    public class UserRepository(FriendsNetworkDbContext context) : IUserRepository
    {
        private readonly FriendsNetworkDbContext _context = context;

        public async Task<User?> Add(User? user)
        {
            try
            {
                if(user == null)
                    throw new ArgumentNullException(nameof(user));

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> Delete(int? UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User?>?> GetAll()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<User?> GetById(int? UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByUsername(string? username)
        {
            try
            {
                return await _context.Users.Where(x => x.username.Equals(username)).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<User?> Update(User? user)
        {
            throw new NotImplementedException();
        }
    }
}
