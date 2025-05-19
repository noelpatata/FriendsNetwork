using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Application.UseCases.V1.Users
{
    public class GetUsersUseCase : GenericUseCase<GetUsersRequest, GetUsersResponse>
    {
        public GetUsersUseCase(
            IHandler<GetUsersRequest, GetUsersResponse?> handler,
            IValidator<GetUsersRequest?> validator,
            IPresenter<GetUsersResponse> presenter)
            : base(handler, validator, presenter)
        {
        }
    }
}
