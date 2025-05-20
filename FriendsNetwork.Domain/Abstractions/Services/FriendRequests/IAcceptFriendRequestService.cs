using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Services.FriendRequests
{
    public interface IAcceptFriendRequestService
    {
        Task<FriendRequest> AcceptFriendRequestAsync(long userId, Guid friendOnlineId);
    }
}
