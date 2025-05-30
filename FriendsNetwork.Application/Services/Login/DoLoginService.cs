using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Login;
using FriendsNetwork.Domain.Abstractions.Services.Security;

public class DoLoginService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenGenerator tokenGenerator) : IDoLoginService
{
    public async Task<string> DoLoginServiceAsync(string username, string password)
    {
        var user = await userRepository.GetByUsername(username);
        if (user == null || !passwordHasher.VerifyPassword(password, user.hashed_password, user.salt))
        {
            throw new InvalidOperationException("Invalid username or password");
        }

        return tokenGenerator.Generate(user.id);
    }
}
