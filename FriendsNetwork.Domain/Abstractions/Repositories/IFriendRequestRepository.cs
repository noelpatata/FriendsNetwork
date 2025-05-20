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
        Task<FriendRequest> SendFriendRequest(long? userId, Guid? friendOnlineId);
        Task<FriendRequest> AcceptFriendRequest(long? userId, Guid? friendOnlineId);
        Task<FriendRequest> DenyFriendRequest(long? userId, Guid? friendOnlineId);
        Task<IEnumerable<FriendRequest>> GetPendingFriendRequests(long? userId);
        Task<bool> DeleteFriendRequests(long user1Id, long user2Id);
    }
}
