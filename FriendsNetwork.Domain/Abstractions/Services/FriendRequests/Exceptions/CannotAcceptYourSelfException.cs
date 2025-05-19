using System.Runtime.Serialization;

namespace FriendsNetwork.Application.Services.FriendRequests.Exceptions
{
    public class CannotAcceptYourSelfException : Exception
    {
        public CannotAcceptYourSelfException()
            : base("You cannot accept yourself as a friend.")
        {
        }

        public CannotAcceptYourSelfException(string message)
            : base(message)
        {
        }

        public CannotAcceptYourSelfException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
