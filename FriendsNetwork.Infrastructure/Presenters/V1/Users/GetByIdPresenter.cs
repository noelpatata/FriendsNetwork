using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Users;

public class GetByIdPresenter : IPresenter<GetByIdResponse?>
{
    public Task<AppResponse<GetByIdResponse?>> PresentAsync(GetByIdResponse? response)
    {
        var result = new AppResponse<GetByIdResponse?>
        {
            success = true,
            content = response,
            message = "User fetched successfully."
        };

        return Task.FromResult(result);
    }
}