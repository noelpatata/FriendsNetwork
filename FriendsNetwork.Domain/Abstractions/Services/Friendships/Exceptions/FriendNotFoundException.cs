using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FriendsNetwork.Domain.Abstractions.Services.Friendships.Exceptions
{
    public class FriendNotFoundException: Exception
    {
        public FriendNotFoundException()
            : base("Friend not found.")
        {
        }

        public FriendNotFoundException(string message)
            : base(message)
        {
        }

        public FriendNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }


    }
}
