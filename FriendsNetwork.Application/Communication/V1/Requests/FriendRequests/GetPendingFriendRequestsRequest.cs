using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsNetwork.Application.Communication.V1.Requests.FriendRequests
{
    public class GetPendingFriendRequestsRequest
    {
        public long userId { get; set; }
    }
}
