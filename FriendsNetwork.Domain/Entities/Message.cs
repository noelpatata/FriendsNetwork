namespace FriendsNetwork.Domain.Entities;

public class Message
{
    public long Id { get; set; }
    public string type { get; set; } = string.Empty;
    public long senderId { get; set; }
    public string message { get; set; } = string.Empty;
    public Guid receiverOnlineId { get; set; }
}