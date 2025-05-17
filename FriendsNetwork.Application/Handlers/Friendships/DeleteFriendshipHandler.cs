using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Friendships;

namespace FriendsNetwork.Application.Handlers.Friendships
{
    public class DeleteFriendshipHandler(IDeleteFriendShipService deleteFriendService) : IHandler<DeleteFriendShipRequest, bool>
    {
        private readonly IDeleteFriendShipService _deleteFriendService = deleteFriendService ?? throw new ArgumentNullException(nameof(deleteFriendService));
        
        public async Task<bool> HandleAsync(DeleteFriendShipRequest request)
        {
            var deleted = await _deleteFriendService.DeleteFriendShipServiceAsync(request.userId, request.friendOnlineId);
            return deleted;

        }
    }
}
