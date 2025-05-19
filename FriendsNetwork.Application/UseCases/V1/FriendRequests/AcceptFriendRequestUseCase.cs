using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Requests.FriendResponse;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;

namespace FriendsNetwork.Application.UseCases.V1.FriendRequests
{
    public class AcceptFriendRequestUseCase : GenericUseCase<AcceptFriendRequestRequest, AcceptFriendRequestResponse>
    {
        public AcceptFriendRequestUseCase(
            IHandler<AcceptFriendRequestRequest, AcceptFriendRequestResponse?> handler,
            IValidator<AcceptFriendRequestRequest?> validator,
            IPresenter<AcceptFriendRequestResponse> presenter)
            : base(handler, validator, presenter)
        {
        }
    }
}
