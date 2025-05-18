using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.FriendRequests
{
    public class SendFriendRequestService : ISendFriendRequestService
    {
        private readonly IFriendRequestRepository? _friendRequestRepository;
        public Task<FriendRequest> SendFriendRequestAsync(Guid? friendOnlineId)
        {
            if (_friendRequestRepository == null)
            {
                throw new ArgumentNullException(nameof(_friendRequestRepository));
            }

            return _friendRequestRepository.SendFriendRequest(friendOnlineId);
        }
    }
}
