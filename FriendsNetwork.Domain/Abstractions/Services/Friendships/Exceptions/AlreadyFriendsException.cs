using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsNetwork.Domain.Abstractions.Services.Friendships.Exceptions
{
    public class AlreadyFriendsException: Exception
    {
        public AlreadyFriendsException()
            : base("You are already friends.")
        {
        }

        public AlreadyFriendsException(string message)
            : base(message)
        {
        }

        public AlreadyFriendsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
