using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Users
{
    public class GetByUsernamePresenter : IPresenter<GetByUsernameResponse>
    {
        public Task<AppResponse<GetByUsernameResponse?>> PresentAsync(GetByUsernameResponse? response)
        {
            var result = new AppResponse<GetByUsernameResponse?>
            {
                success = true,
                content = response,
                message = "User retrieved successfully."
            };

            return Task.FromResult(result);
        }
    }
}
