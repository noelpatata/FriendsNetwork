using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Users
{
    public class GetByUsernamePresenter : IPresenter<GetByUsernameResponse>
    {
        public async Task<AppResponse<GetByUsernameResponse?>?> PresentAsync(GetByUsernameResponse? response)
        {
            return new AppResponse<GetByUsernameResponse?>
            {
                success = true,
                content = response,
                message = "User retrieved successfully."
            };
        }
    }
}
