using FriendsNetwork.Application.Communication.V1.Responses.Notifications;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Notifications;

public class SaveNotificationPresenter: IPresenter<SaveNotificationResponse?>
{
    public Task<AppResponse<SaveNotificationResponse?>> PresentAsync(SaveNotificationResponse? response)
    {
        var result= new AppResponse<SaveNotificationResponse?>
        {
            success = true,
            content = response,
            message = "Notification saved successfully."
        };
        return Task.FromResult(result);
    }
}