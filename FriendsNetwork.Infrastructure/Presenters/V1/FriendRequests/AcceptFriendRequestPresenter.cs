using FriendsNetwork.Application.Communication.V1.Requests.FriendResponse;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.FriendRequests
{
    public class AcceptFriendRequestPresenter : IPresenter<AcceptFriendRequestResponse>
    {
        public async Task<AppResponse<AcceptFriendRequestResponse?>> PresentAsync(AcceptFriendRequestResponse? response)
        {
            return new AppResponse<AcceptFriendRequestResponse?>
            {
                success = true,
                content = response,
                message = "Friend request accepted successfully."
            };
        }
    }
}
