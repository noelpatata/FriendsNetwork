using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Services.FriendRequests
{
    public interface ISendFriendRequestService
    {
        Task<FriendRequest> SendFriendRequestAsync(long userId, Guid friendOnlineId);
    }
}
