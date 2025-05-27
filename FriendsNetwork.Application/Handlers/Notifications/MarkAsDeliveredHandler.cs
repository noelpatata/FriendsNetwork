using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.Notifications;
using FriendsNetwork.Application.Communication.V1.Responses.Notifications;
using FriendsNetwork.Application.Communication.V1.ViewModels.Notifications;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Notifications;

namespace FriendsNetwork.Application.Handlers.Notifications;

public class MarkAsDeliveredHandler(
    IMarkAsDeliveredService service,
    IMapper mapper
    ): IHandler<MarkAsDeliveredRequest, MarkAsDeliveredResponse>
{
    public async Task<MarkAsDeliveredResponse?> HandleAsync(MarkAsDeliveredRequest? request)
    {
        var marked = await service.MarkNotificationAsDelivered(request!.notificationId);
        var mapped = mapper.Map<SaveNotificationViewModel?>(marked);
        var response = new MarkAsDeliveredResponse()
        {
            viewModel = mapped
        };

        return response;
    }
}