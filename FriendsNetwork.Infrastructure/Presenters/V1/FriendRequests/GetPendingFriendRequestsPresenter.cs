using FriendsNetwork.Application.Communication.V1.Requests.FriendResponse;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.FriendRequests
{
    public class SendFriendRequestPresenter : IPresenter<SendFriendRequestResponse>
    {
        public async Task<AppResponse<SendFriendRequestResponse?>> PresentAsync(SendFriendRequestResponse? response)
        {
            return new AppResponse<SendFriendRequestResponse?>
            {
                success = true,
                content = response,
                message = "Friend requests sended successfully."
            };
        }
    }
}
