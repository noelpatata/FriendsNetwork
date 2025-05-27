using FriendsNetwork.Application.Communication.V1.Responses.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.FriendRequests
{
    public class DenyFriendRequestPresenter : IPresenter<DenyFriendRequestResponse?>
    {
        public Task<AppResponse<DenyFriendRequestResponse?>> PresentAsync(DenyFriendRequestResponse? response)
        {
            var result = new AppResponse<DenyFriendRequestResponse?>
            {
                success = true,
                content = response,
                message = "Friend request denied successfully."
            };
            return Task.FromResult(result);
        }
    }
}
