using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;

namespace FriendsNetwork.Application.UseCases.V1.Users
{
    public class GetByUsernameUseCase : GenericUseCase<GetByUsernameRequest, GetByUsernameResponse>
    {
        public GetByUsernameUseCase(
            IHandler<GetByUsernameRequest, GetByUsernameResponse?> handler,
            IValidator<GetByUsernameRequest> validator,
            IPresenter<GetByUsernameResponse> presenter)
            : base(handler, validator, presenter)
        {
        }
    }
}
