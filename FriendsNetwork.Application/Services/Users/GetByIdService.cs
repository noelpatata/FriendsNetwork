using FriendsNetwork.Application.UseCases.V1.Users;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Security;
using FriendsNetwork.Domain.Abstractions.Services.Users;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.Users;

public class GetByIdService(IUserRepository userRepository ): IGetByIdService
{
    public async Task<User?> GetByIdServiceAsync(long userId)
    {
        return await userRepository.GetById(userId);
    }
}