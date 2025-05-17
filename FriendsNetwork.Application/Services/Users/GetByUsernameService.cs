using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Users;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.Users
{
    public class GetByUsernameService : IGetByUsernameService
    {
        private readonly IUserRepository _userRepository;
        public GetByUsernameService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        Task<User?> IGetByUsernameService.GetByUsernameServiceAsync(string? username)
        {
            return _userRepository.GetByUsername(username);
        }
    }
}
