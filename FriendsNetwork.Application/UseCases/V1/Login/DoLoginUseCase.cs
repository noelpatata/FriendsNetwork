using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Application.Communication.V1.Requests.Login;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Application.Communication.V1.Responses.Login;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
namespace FriendsNetwork.Application.UseCases.V1.Login
{
    public class DoLoginUseCase : GenericUseCase<DoLoginRequest, DoLoginResponse>
    {
        public DoLoginUseCase(
            IHandler<DoLoginRequest, DoLoginResponse?> handler,
            IValidator<DoLoginRequest> validator,
            IPresenter<DoLoginResponse> presenter)
            : base(handler, validator, presenter)
        {
        }
    }

}
