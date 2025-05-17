using FriendsNetwork.Application.Communication.V1.Responses.Login;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Login
{
    public class DoLoginPresenter : IPresenter<DoLoginResponse>
    {
        public async Task<AppResponse<DoLoginResponse?>?> PresentAsync(DoLoginResponse? response)
        {
            return new AppResponse<DoLoginResponse?>
            {
                success = true,
                content = response,
                message = "Logged in successfully."
            };
        }
    }
}
