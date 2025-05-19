using System.Runtime.Serialization;

namespace FriendsNetwork.Application.Services.FriendRequests.Exceptions
{
    public class CannotAddYourSelfException : Exception
    {
        public CannotAddYourSelfException()
            : base("You cannot add yourself as a friend.")
        {
        }

        public CannotAddYourSelfException(string message)
            : base(message)
        {
        }

        public CannotAddYourSelfException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CannotAddYourSelfException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
