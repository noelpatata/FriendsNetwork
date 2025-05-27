using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Notifications;
using FriendsNetwork.Application.Communication.V1.Responses.Notifications;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;

namespace FriendsNetwork.Application.UseCases.V1.Notifications;

public class SaveNotificationUseCase: GenericUseCase<SaveNotificationRequest, SaveNotificationResponse>
{
    public SaveNotificationUseCase(
        IHandler<SaveNotificationRequest, SaveNotificationResponse?> handler,
        IValidator<SaveNotificationRequest?> validator,
        IPresenter<SaveNotificationResponse> presenter)
        : base(handler, validator, presenter)
    {
    }
}