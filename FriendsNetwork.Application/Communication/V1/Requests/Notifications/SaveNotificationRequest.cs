namespace FriendsNetwork.Application.Communication.V1.Requests.Notifications;

public class SaveNotificationRequest
{
    public long userId { get; set; }
    public Guid friendOnlineId { get; set; }
    public string message { get; set; }
}