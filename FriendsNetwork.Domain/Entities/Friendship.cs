
namespace FriendsNetwork.Domain.Entities
{
    public class FriendShip
    {
        public long id { get; set; }
        public long user_id { get; set; }
        public User User { get; set; }
        public long friend_id { get; set; }
        public User Friend { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}
