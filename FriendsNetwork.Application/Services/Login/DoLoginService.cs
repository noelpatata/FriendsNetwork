using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Login;
using FriendsNetwork.Domain.Abstractions.Services.Security;

public class DoLoginService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenGenerator tokenGenerator) : IDoLoginService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

    public async Task<string> DoLoginServiceAsync(string username, string password)
    {
        var user = await _userRepository.GetByUsername(username);
        if (user == null || !_passwordHasher.VerifyPassword(password, user.hashed_password, user.salt))
        {
            throw new InvalidOperationException("Invalid username or password");
        }

        return _tokenGenerator.Generate(user.id);
    }
}
