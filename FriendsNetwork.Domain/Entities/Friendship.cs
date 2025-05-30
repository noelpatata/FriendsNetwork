﻿
namespace FriendsNetwork.Domain.Entities
{
    public class Friendship
    {
        public long id { get; set; }
        public long user_id { get; set; }
        public User User { get; set; } = null!;
        public long friend_id { get; set; }
        public User Friend { get; set; } = null!;

        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}
