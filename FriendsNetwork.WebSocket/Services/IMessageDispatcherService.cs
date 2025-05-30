using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.WebSocket.Services;

public interface IMessageDispatcherService
{
    Task DispatchAsync(Message message);
}