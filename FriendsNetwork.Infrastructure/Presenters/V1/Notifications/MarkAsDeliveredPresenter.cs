using FriendsNetwork.Application.Communication.V1.Responses.Notifications;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Notifications;

public class MarkAsDeliveredPresenter : IPresenter<MarkAsDeliveredResponse?>
{
    public Task<AppResponse<MarkAsDeliveredResponse?>> PresentAsync(MarkAsDeliveredResponse? response)
    {
        var result = new AppResponse<MarkAsDeliveredResponse?>
        {
            success = true,
            content = response,
            message = "Notifications fetched successfully."
        };
        return Task.FromResult(result);
    }
}