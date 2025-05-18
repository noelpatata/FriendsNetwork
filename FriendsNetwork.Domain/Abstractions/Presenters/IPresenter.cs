using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Domain.Abstractions.Presenters
{
    public interface IPresenter<TResponse>
    {
        Task<AppResponse<TResponse>> PresentAsync(TResponse response);
    }
}
