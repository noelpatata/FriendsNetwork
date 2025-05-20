using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Services.Users
{
    public interface IGetUsersService
    {
        Task<IEnumerable<User?>> GetUsersServiceAsync();
    }
}
