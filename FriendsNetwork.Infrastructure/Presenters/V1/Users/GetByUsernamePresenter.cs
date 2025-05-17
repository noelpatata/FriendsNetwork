using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Users
{
    public class GetUsersPresenter : IPresenter<GetUsersResponse>
    {
        public async Task<AppResponse<GetUsersResponse?>?> PresentAsync(GetUsersResponse? response)
        {
            return new AppResponse<GetUsersResponse?>
            {
                success = true,
                content = response,
                message = "Users retrieved successfully."
            };
        }
    }
}
