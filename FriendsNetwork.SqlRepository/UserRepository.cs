using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Entities;
using FriendsNetwork.SqlRepository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FriendsNetwork.PosgreSqlRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly FriendsDbContext _context;

        public UserRepository(FriendsDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Add(User? user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<bool> Delete(int? UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User?>?> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<User?> GetById(int? UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByUsername(string? username)
        {
            return await _context.Users.Where(x => x.username.Equals(username)).FirstOrDefaultAsync();
        }

        public Task<User?> Update(User? user)
        {
            throw new NotImplementedException();
        }
    }
}
