using FriendsNetwork.Application.Communication.V1.ViewModels.Users;

namespace FriendsNetwork.Application.Communication.V1.ViewModels.Notifications;

public class NotificationViewModel
{
    public long id { get; set; }
    public string message { get; set; } = string.Empty;
    public UserViewModel? sender { get; set; }
    public UserViewModel? receiver { get; set; }
}