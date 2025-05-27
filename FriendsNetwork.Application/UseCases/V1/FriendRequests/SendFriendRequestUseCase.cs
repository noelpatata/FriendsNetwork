using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Responses.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;

namespace FriendsNetwork.Application.UseCases.V1.FriendRequests
{
    public class SendFriendRequestUseCase : GenericUseCase<SendFriendRequestRequest, SendFriendRequestResponse>
    {
        public SendFriendRequestUseCase(
            IHandler<SendFriendRequestRequest, SendFriendRequestResponse?> handler,
            IValidator<SendFriendRequestRequest?> validator,
            IPresenter<SendFriendRequestResponse> presenter)
            : base(handler, validator, presenter)
        {
        }
    }
}
