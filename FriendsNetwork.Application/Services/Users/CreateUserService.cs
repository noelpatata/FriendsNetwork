using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Security;
using FriendsNetwork.Domain.Abstractions.Services.Users;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.Users
{
    public class CreateUserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher): ICreateUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public Task<User?> CreateUserServiceAsync(string username, string password)
        {
            var (hash, salt) = _passwordHasher.HashPassword(password);

            var user = new User
            {
                username = username,
                online_id = Guid.NewGuid(),
                hashed_password = hash,
                salt = salt
            };

            return _userRepository.Add(user);
        }
    }
}
