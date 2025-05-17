using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Friendships
{
    public class DeleteFriendshipPresenter: IPresenter<DeleteFriendshipResponse>
    {
        public async Task<AppResponse<DeleteFriendshipResponse?>?> PresentAsync(DeleteFriendshipResponse? response)
        {
            return new AppResponse<DeleteFriendshipResponse?>
            {
                success = true,
                content = response,
                message = "Friendship deleted successfully."
            };
        }
    }
}
