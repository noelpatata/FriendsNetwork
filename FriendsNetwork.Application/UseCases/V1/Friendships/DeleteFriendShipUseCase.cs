using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;

namespace FriendsNetwork.Application.UseCases.V1.Friendships
{
    public class DeleteFriendshipUseCase : GenericUseCase<DeleteFriendshipRequest, DeleteFriendshipResponse>
    {
        public DeleteFriendshipUseCase(
            IHandler<DeleteFriendshipRequest, DeleteFriendshipResponse?> handler,
            IValidator<DeleteFriendshipRequest?> validator,
            IPresenter<DeleteFriendshipResponse> presenter)
            : base(handler, validator, presenter)
        {
        }
    }
}
