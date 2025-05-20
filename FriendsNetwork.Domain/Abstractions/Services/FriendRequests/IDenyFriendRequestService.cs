using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Services.FriendRequests
{
    public interface IDenyFriendRequestService
    {
        Task<FriendRequest> DenyFriendRequestAsync(long userId, Guid friendOnlineId);
    }
}
