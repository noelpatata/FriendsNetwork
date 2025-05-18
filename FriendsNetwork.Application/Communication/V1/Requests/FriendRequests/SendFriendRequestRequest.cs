using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsNetwork.Application.Communication.V1.Requests.FriendRequests
{
    public class SendFriendRequestRequest
    {
        public Guid FriendOnlineId { get; set; }
    }
}
