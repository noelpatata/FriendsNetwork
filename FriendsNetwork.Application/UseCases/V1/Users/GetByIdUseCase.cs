using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;

namespace FriendsNetwork.Application.UseCases.V1.Users;

public class GetByIdUseCase : GenericUseCase<GetByIdRequest, GetByIdResponse>
{
    public GetByIdUseCase(
        IHandler<GetByIdRequest, GetByIdResponse?> handler,
        IValidator<GetByIdRequest?> validator,
        IPresenter<GetByIdResponse> presenter):
        base(handler, validator, presenter)
    {
    }
}