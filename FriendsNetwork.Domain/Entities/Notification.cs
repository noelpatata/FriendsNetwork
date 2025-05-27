namespace FriendsNetwork.Domain.Entities;

public class Notification
{
    public long id { get; set; }
    public long fromUserId { get; set; }
    public long toUserId { get; set; }
    public string message { get; set; }
    public bool delivered { get; set; }
    public DateTime sentAt { get; set; } = DateTime.UtcNow;
    public User SourceUser { get; set; } = null!;
    public User DestinationUser { get; set; } = null!;
}