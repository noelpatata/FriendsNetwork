using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.Notifications;
using FriendsNetwork.Application.Communication.V1.Responses.Notifications;
using FriendsNetwork.Application.Communication.V1.ViewModels.Notifications;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Notifications;

namespace FriendsNetwork.Application.Handlers.Notifications;

public class SaveNotificationHandler(
    ISaveNotificationService saveNotificationService,
    IMapper mapper) : IHandler<SaveNotificationRequest, SaveNotificationResponse>
{
    public async Task<SaveNotificationResponse?> HandleAsync(SaveNotificationRequest? request)
    {
        var savedNotification = await saveNotificationService.SaveNotification(request!.userId, request!.friendOnlineId, request!.message);
        var mappedSavedNotification = mapper.Map<SaveNotificationViewModel?>(savedNotification);
        var mappedAccepted = new SaveNotificationResponse
        {
            viewModel = mappedSavedNotification
        };
        return mappedAccepted;
    }
}