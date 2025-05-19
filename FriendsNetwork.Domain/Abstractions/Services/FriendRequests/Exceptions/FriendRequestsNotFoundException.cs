using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FriendsNetwork.Domain.Abstractions.Services.FriendRequests.Exceptions
{
    public class FriendRequestsNotFoundException : Exception
    {
        public FriendRequestsNotFoundException()
            : base("There are not friend requests from this user.")
        {
        }

        public FriendRequestsNotFoundException(string message)
            : base(message)
        {
        }

        public FriendRequestsNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
