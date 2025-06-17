using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Users
{
    public class CreateUserPresenter :IPresenter<CreateUserResponse?>
    {
        public Task<AppResponse<CreateUserResponse?>> PresentAsync(CreateUserResponse? response)
        {
            var result = new AppResponse<CreateUserResponse?>
            {
                success = true,
                content = response,
                message = "User created successfully."
            };

            return Task.FromResult(result);
        }
    }
}
