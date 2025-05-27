using FriendsNetwork.Application.Communication.V1.Responses.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.FriendRequests
{
    public class AcceptFriendRequestPresenter : IPresenter<AcceptFriendRequestResponse?>
    {
        public Task<AppResponse<AcceptFriendRequestResponse?>> PresentAsync(AcceptFriendRequestResponse? response)
        {
            var result= new AppResponse<AcceptFriendRequestResponse?>
            {
                success = true,
                content = response,
                message = "Friend request accepted successfully."
            };
            return Task.FromResult(result);
        }
    }
}
