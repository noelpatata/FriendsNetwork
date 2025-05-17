
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Friendships
{
    public class GetFriendShipsPresenter : IPresenter<GetFriendShipsResponse>
    {
        public async Task<AppResponse<GetFriendShipsResponse?>?> PresentAsync(GetFriendShipsResponse? response)
        {
            return new AppResponse<GetFriendShipsResponse?>
            {
                success = true,
                content = response,
                message = "Friendships fetched successfully."
            };
        }
    }
}
