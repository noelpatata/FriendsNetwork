using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Users;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.Users
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IUserRepository _userRepository;
        public GetUsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        Task<IEnumerable<User?>?> IGetUsersService.GetUsersServiceAsync()
        {
            return _userRepository.GetAll();
        }
    }
}
