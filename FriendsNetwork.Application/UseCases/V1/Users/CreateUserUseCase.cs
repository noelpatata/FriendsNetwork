using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Login;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Login;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Application.UseCases.V1.Users
{
    public class CreateUserUseCase : GenericUseCase<CreateUserRequest, CreateUserResponse>
    {
        public CreateUserUseCase(
            IHandler<CreateUserRequest, CreateUserResponse?> handler,
            IValidator<CreateUserRequest> validator,
            IPresenter<CreateUserResponse> presenter)
            : base(handler, validator, presenter)
        {
        }
    }
}
