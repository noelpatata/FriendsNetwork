
using FriendsNetwork.Application.Communication.V1.ViewModels.Friendships;

namespace FriendsNetwork.Application.Communication.V1.Responses.Friendships
{
    public class GetFriendshipsResponse
    {
        public IEnumerable<FriendShipViewModel?>? friendsViewModel { get; set; } = [];
    }
}
