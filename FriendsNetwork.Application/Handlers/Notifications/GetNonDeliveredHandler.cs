using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.Notifications;
using FriendsNetwork.Application.Communication.V1.Responses.Notifications;
using FriendsNetwork.Application.Communication.V1.ViewModels.Notifications;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Notifications;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Handlers.Notifications;

public class GetNonDeliveredHandler(
    IGetNonDeliveredService service,
    IMapper mapper
    ): IHandler<GetNonDeliveredRequest, GetNonDeliveredResponse>
{
    public async Task<GetNonDeliveredResponse?> HandleAsync(GetNonDeliveredRequest? request)
    {
        var notifications = await service.GetNonDeliveredNotifications(request!.userId);
        var mapped = mapper.Map<IEnumerable<NotificationViewModel>>(notifications);
        var response = new GetNonDeliveredResponse
        {
            viewModel = mapped
        };

        return response;
    }
}