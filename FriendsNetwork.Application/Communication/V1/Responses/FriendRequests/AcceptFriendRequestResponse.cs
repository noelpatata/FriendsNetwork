using FriendsNetwork.Application.Communication.V1.ViewModels.FriendRequests;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Communication.V1.Requests.FriendResponse
{
    public class AcceptFriendRequestResponse
    {
        public FriendRequestViewModel? viewModel { get; set; }
    }
}
