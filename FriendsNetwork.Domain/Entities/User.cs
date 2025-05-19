
using System.Collections.ObjectModel;


namespace FriendsNetwork.Domain.Entities
{
    public class User
    {
        public long id { get; set; }

        public string username { get; set; } = "";
        public string? hashed_password { get; set; }
        public string? salt { get; set; }

        public Guid? online_id { get; set; } = Guid.NewGuid();

        public ICollection<Friendship> FriendsOf { get; set; } = new Collection<Friendship>();
    }
}
