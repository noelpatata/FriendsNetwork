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
        Task<FriendRequest> SendFriendRequest(long userId, long frienduserId, User friend);
        Task<bool> AcceptFriendRequest(FriendRequest fr);
        Task<bool> DenyFriendRequest(FriendRequest fr);
        Task<IEnumerable<FriendRequest>> GetPendingFriendRequests(long userId);
        Task<bool> DeleteFriendRequests(long user1Id, long user2Id);
        Task<FriendRequest?> GetReceivedFriendRequestFromUser(long user1Id, long user2Id);
        Task<bool> PreviousFriendRequestsSent(long user1, long user2);
        
    }
}
