using FriendsNetwork.WebSocket.Dispatchers;
using FriendsNetwork.WebSocket.Managers;

namespace FriendsNetwork.WebSocket.Factories;

public class WebSocketMessageHandlerFactory(
    IServiceProvider serviceProvider,
    IWebSocketConnectionManager connectionManager)
{
    public IWebSocketMessageDispatcher GetDispatcher(string messageType)
    {
        return messageType switch
        {
            "message" => new MessageService(serviceProvider, connectionManager),
            _ => throw new InvalidOperationException($"Unknown message type: {messageType}")
        };
    }
}
