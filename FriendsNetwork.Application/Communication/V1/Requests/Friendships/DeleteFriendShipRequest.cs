using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsNetwork.Application.Communication.V1.Requests.Friendships
{
    public class DeleteFriendshipRequest
    {
        public long? userId { get; set; }
        public Guid? friendOnlineId { get; set; }
    }
}
