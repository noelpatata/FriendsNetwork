using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsername(string username);
        Task<IEnumerable<User?>> GetAll();
        Task<User> Add(User user);
        Task<User?> GetByOnlineId(Guid onlineId);
    }
}
