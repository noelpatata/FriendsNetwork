using FriendsNetwork.Application.Communication.V1.Responses.Notifications;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Notifications;

public class GetNonDeliveredPresenter: IPresenter<GetNonDeliveredResponse?>
{
    public Task<AppResponse<GetNonDeliveredResponse?>> PresentAsync(GetNonDeliveredResponse? response)
    {
        var result= new AppResponse<GetNonDeliveredResponse?>
        {
            success = true,
            content = response,
            message = "Notifications fetched successfully."
        };
        return Task.FromResult(result);
    }
}