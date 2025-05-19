using FriendsNetwork.Application.Communication.V1.Requests.FriendResponse;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.FriendRequests
{
    public class DenyFriendRequestPresenter : IPresenter<DenyFriendRequestResponse>
    {
        public async Task<AppResponse<DenyFriendRequestResponse?>> PresentAsync(DenyFriendRequestResponse? response)
        {
            return new AppResponse<DenyFriendRequestResponse?>
            {
                success = true,
                content = response,
                message = "Friend request denied successfully."
            };
        }
    }
}
