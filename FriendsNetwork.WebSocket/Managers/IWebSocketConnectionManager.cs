namespace FriendsNetwork.WebSocket.Managers;

public interface IWebSocketConnectionManager
{
    IEnumerable<long> GetAllConnectedUserIds();
    void AddSocket(long userId, System.Net.WebSockets.WebSocket socket);
    Task RemoveSocketAsync(long userId);
    Task SendMessageAsync(long userId, string message);
    Task ReceiveLoopAsync(long userId, System.Net.WebSockets.WebSocket socket);
    bool IsUserConnected(long userId);
    System.Net.WebSockets.WebSocket? GetSocketByUserId(long userId);
}