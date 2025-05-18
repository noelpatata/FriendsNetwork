using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsNetwork.Application.Communication.V1.ViewModels.FriendRequests;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Communication.V1.Requests.FriendResponse
{
    public class GetPendingFriendRequestsResponse
    {
        public IEnumerable<FriendRequestViewModel?>? viewModels { get; set;}
    }
}
