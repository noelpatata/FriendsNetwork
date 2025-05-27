using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Notifications;
using FriendsNetwork.Application.Communication.V1.Responses.Notifications;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;

namespace FriendsNetwork.Application.UseCases.V1.Notifications;

public class GetNonDeliveredUseCase: GenericUseCase<GetNonDeliveredRequest, GetNonDeliveredResponse>
{
    public GetNonDeliveredUseCase(
        IHandler<GetNonDeliveredRequest, GetNonDeliveredResponse?> handler,
        IValidator<GetNonDeliveredRequest?> validator,
        IPresenter<GetNonDeliveredResponse> presenter)
        : base(handler, validator, presenter)
    {
    }
}