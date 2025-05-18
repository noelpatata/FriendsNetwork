using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsNetwork.Domain.Entities
{
    public class FriendRequest
    {
        public long id { get; set; }
        public long sender_id { get; set; }
        public User Sender { get; set; }
        public long receiver_id { get; set; }
        public User Receiver { get; set; }
        public bool accepted { get; set; } = false;
        public DateTime sentAt { get; set; } = DateTime.UtcNow;
    }
}
