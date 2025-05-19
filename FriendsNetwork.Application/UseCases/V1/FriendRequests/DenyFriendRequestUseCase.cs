using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Requests.FriendResponse;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;

namespace FriendsNetwork.Application.UseCases.V1.FriendRequests
{
    public class DenyFriendRequestUseCase : GenericUseCase<DenyFriendRequestRequest, DenyFriendRequestResponse>
    {
        public DenyFriendRequestUseCase(
            IHandler<DenyFriendRequestRequest, DenyFriendRequestResponse?> handler,
            IValidator<DenyFriendRequestRequest?> validator,
            IPresenter<DenyFriendRequestResponse> presenter)
            : base(handler, validator, presenter)
        {
        }
    }
}
