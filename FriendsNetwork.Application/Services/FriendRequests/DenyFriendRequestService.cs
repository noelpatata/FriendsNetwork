using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.FriendRequests
{
    public class DenyFriendRequestService (IFriendRequestRepository repo) : IDenyFriendRequestService
    {
        private readonly IFriendRequestRepository? _friendRequestRepository = repo;
        public Task<FriendRequest> DenyFriendRequestAsync(long? userId, Guid? friendOnlineId)
        {
            if (_friendRequestRepository == null)
            {
                throw new ArgumentNullException(nameof(_friendRequestRepository));
            }

            return _friendRequestRepository.DenyFriendRequest(userId, friendOnlineId);
        }
    }
}
