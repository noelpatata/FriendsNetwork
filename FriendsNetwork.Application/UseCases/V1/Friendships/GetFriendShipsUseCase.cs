using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;

namespace FriendsNetwork.Application.UseCases.V1.Friendships
{
    public class GetFriendshipsUseCase : GenericUseCase<GetFriendshipsRequest, GetFriendshipsResponse>
    {
        public GetFriendshipsUseCase(
            IHandler<GetFriendshipsRequest, GetFriendshipsResponse?> handler,
            IValidator<GetFriendshipsRequest?> validator,
            IPresenter<GetFriendshipsResponse> presenter)
            : base(handler, validator, presenter)
        {
        }
    }
}
