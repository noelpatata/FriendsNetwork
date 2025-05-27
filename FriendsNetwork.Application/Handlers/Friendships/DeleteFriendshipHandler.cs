using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Application.Communication.V1.ViewModels.Friendships;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Friendships;

namespace FriendsNetwork.Application.Handlers.Friendships
{
    public class DeleteFriendshipHandler(IDeleteFriendshipService deleteFriendService) : IHandler<DeleteFriendshipRequest, DeleteFriendshipResponse>
    {
        private readonly IDeleteFriendshipService _deleteFriendService = deleteFriendService ?? throw new ArgumentNullException(nameof(deleteFriendService));
        
        public async Task<DeleteFriendshipResponse?> HandleAsync(DeleteFriendshipRequest? request)
        {
            var deleted = await _deleteFriendService.DeleteFriendShipServiceAsync(request!.userId, request!.friendOnlineId);

            var mappedDeleted = new DeleteFriendshipResponse
            {
                viewModel = deleted
            };

            return mappedDeleted;

        }
    }
}
