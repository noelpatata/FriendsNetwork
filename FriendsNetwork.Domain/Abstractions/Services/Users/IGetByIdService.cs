using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Services.Users;

public interface IGetByIdService
{
    Task<User?> GetByIdServiceAsync(long userId);

}