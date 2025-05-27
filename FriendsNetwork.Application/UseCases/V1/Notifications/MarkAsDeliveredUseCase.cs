using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Notifications;
using FriendsNetwork.Application.Communication.V1.Responses.Notifications;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;

namespace FriendsNetwork.Application.UseCases.V1.Notifications;

public class MarkAsDeliveredUseCase : GenericUseCase<MarkAsDeliveredRequest, MarkAsDeliveredResponse>
{
    public MarkAsDeliveredUseCase(
        IHandler<MarkAsDeliveredRequest, MarkAsDeliveredResponse?> handler,
        IValidator<MarkAsDeliveredRequest?> validator,
        IPresenter<MarkAsDeliveredResponse> presenter)
        : base(handler, validator, presenter)
    {
    }
}