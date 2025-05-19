using FriendsNetwork.Application.Communication.V1.Responses.Login;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Login
{
    public class DoLoginPresenter : IPresenter<DoLoginResponse?>
    {
        public Task<AppResponse<DoLoginResponse?>> PresentAsync(DoLoginResponse? response)
        {
            var result = new AppResponse<DoLoginResponse?>
            {
                success = true,
                content = response,
                message = "Logged in successfully."
            };
            return Task.FromResult(result);
        }
    }
}
