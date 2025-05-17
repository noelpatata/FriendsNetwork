using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Services.Users
{
    public interface IGetByUsernameService
    {
        Task<User?> GetByUsernameServiceAsync(string? username);
    }
}
