using FriendsNetwork.Application.Communication.V1.ViewModels.Users;

namespace FriendsNetwork.Application.Communication.V1.ViewModels.FriendRequests
{
    public class FriendRequestViewModel
    {
        public bool accepted { get; set; } = false;
        public UserViewModel? Receiver { get; set; }
        public DateTime sentAt { get; set; } = DateTime.UtcNow;
    }
}
