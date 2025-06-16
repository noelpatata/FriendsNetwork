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
        public async Task<User?> CreateUserServiceAsync(string username, string password)
        {
            var (hash, salt) = passwordHasher.HashPassword(password);

            var user = new User
            {
                username = username,
                online_id = Guid.NewGuid(),
                hashed_password = hash,
                salt = salt
            };

            return await userRepository.Add(user);
        }
    }
}
