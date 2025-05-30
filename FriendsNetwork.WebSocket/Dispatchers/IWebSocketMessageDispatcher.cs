using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.WebSocket.Dispatchers;

public interface IWebSocketMessageDispatcher
{
    Task DispatchAsync(Message message);
}