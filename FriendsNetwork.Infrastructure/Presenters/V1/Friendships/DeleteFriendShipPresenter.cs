using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Friendships
{
    public class DeleteFriendShipPresenter: IPresenter<DeleteFriendShipResponse>
    {
        public async Task<AppResponse<DeleteFriendShipResponse?>?> PresentAsync(DeleteFriendShipResponse? response)
        {
            return new AppResponse<DeleteFriendShipResponse?>
            {
                success = true,
                content = response,
                message = "Friendship deleted successfully."
            };
        }
    }
}
