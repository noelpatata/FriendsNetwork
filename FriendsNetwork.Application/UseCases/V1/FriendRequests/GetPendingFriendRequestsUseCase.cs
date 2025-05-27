using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Responses.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;

namespace FriendsNetwork.Application.UseCases.V1.FriendRequests
{
    public class GetPendingFriendRequestsUseCase : GenericUseCase<GetPendingFriendRequestsRequest, GetPendingFriendRequestsResponse>
    {
        public GetPendingFriendRequestsUseCase(
            IHandler<GetPendingFriendRequestsRequest, GetPendingFriendRequestsResponse?> handler,
            IValidator<GetPendingFriendRequestsRequest?> validator,
            IPresenter<GetPendingFriendRequestsResponse> presenter)
            : base(handler, validator, presenter)
        {
        }
    }
}
