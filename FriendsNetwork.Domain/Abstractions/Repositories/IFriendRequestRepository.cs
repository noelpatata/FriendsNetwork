using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Repositories
{
    public interface IFriendRequestRepository
    {
        Task<FriendRequest> SendFriendRequest(Guid? friendOnlineId);
        Task<FriendRequest> AcceptFriendRequest(Guid? friendOnlineId);
        Task<FriendRequest> DenyFriendRequest(Guid? friendOnlineId);
        Task<IEnumerable<FriendRequest>> GetPendingFriendRequests();
    }
}
