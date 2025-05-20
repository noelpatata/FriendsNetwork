using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Users;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.Users
{
    public class GetByUsernameService(IUserRepository userRepository) : IGetByUsernameService
    {
        private readonly IUserRepository _userRepository = userRepository;

        Task<User?> IGetByUsernameService.GetByUsernameServiceAsync(string username)
        {
            return _userRepository.GetByUsername(username);
        }
    }
}
