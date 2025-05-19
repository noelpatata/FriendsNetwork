using FriendsNetwork.Application.Communication.V1.Requests.FriendResponse;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.FriendRequests
{
    public class GetPendingFriendRequestsPresenter : IPresenter<GetPendingFriendRequestsResponse>
    {
        public async Task<AppResponse<GetPendingFriendRequestsResponse?>> PresentAsync(GetPendingFriendRequestsResponse? response)
        {
            return new AppResponse<GetPendingFriendRequestsResponse?>
            {
                success = true,
                content = response,
                message = "Friend request sent successfully."
            };
        }
    }
}
