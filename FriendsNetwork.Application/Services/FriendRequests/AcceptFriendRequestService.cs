using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Services.FriendRequests
{
    public class AcceptFriendRequestService (IFriendRequestRepository repo) : IAcceptFriendRequestService
    {
        private readonly IFriendRequestRepository? _friendRequestRepository = repo;
        public Task<FriendRequest> AcceptFriendRequestAsync(long? userId, Guid? friendOnlineId)
        {
            if (_friendRequestRepository == null)
            {
                throw new ArgumentNullException(nameof(_friendRequestRepository));
            }

            return _friendRequestRepository.AcceptFriendRequest(userId, friendOnlineId);
        }
    }
}
