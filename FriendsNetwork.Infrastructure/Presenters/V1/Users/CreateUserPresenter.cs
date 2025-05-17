using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.FriendsNetwork.Infrastructure.Presenters.V1.Users
{
    public class CreateUserPresenter :IPresenter<CreateUserResponse>
    {
        public async Task<AppResponse<CreateUserResponse?>?> PresentAsync(CreateUserResponse? response)
        {
            return new AppResponse<CreateUserResponse?>
            {
                success = true,
                content = response,
                message = "User created successfully."
            };
        }
    }
}
