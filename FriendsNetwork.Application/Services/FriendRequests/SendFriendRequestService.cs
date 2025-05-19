using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.FriendRequests
{
    public class SendFriendRequestService (IFriendRequestRepository repo): ISendFriendRequestService
    {
        private readonly IFriendRequestRepository? _friendRequestRepository = repo;
        public Task<FriendRequest> SendFriendRequestAsync(long? userId, Guid? friendOnlineId)
        {
            if (_friendRequestRepository == null)
            {
                throw new ArgumentNullException(nameof(_friendRequestRepository));
            }

            return _friendRequestRepository.SendFriendRequest(userId, friendOnlineId);
        }
    }
}
