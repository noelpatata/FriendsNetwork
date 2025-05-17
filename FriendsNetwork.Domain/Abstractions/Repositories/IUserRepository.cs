using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int? UserId);
        Task<User?> GetByUsername(string? username);
        Task<IEnumerable<User?>?> GetAll();
        Task<User?> Add(User? user);
        Task<User?> Update(User? user);

        Task<bool> Delete(int? UserId);
    }
}
