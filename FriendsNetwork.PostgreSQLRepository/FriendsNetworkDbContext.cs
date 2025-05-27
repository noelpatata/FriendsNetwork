using Microsoft.EntityFrameworkCore;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.PosgreSqlRepository
{
    public class FriendsNetworkDbContext : DbContext
    {
        public FriendsNetworkDbContext(DbContextOptions<FriendsNetworkDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        // Mapear entidades manualmente si lo prefieres:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //friendship constraints
            modelBuilder.Entity<Friendship>()
                .HasIndex(f => new { f.user_id, f.friend_id })
                .IsUnique();

            modelBuilder.Entity<Friendship>()
                .ToTable(t => t.HasCheckConstraint("CK_Friendship_NoSelfFriend", "user_id <> friend_id"));

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.user_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.Friend)
                .WithMany(u => u.FriendsOf)
                .HasForeignKey(f => f.friend_id)
                .OnDelete(DeleteBehavior.Cascade);

            // FriendRequest constraints
            modelBuilder.Entity<FriendRequest>()
                .HasIndex(f => new { f.sender_id, f.receiver_id })
                .IsUnique(); // Prevent duplicate requests

            modelBuilder.Entity<FriendRequest>()
                .ToTable(t => t.HasCheckConstraint("CK_Request_NoSelfRequest", "sender_id <> receiver_id"));

            modelBuilder.Entity<FriendRequest>()
                .HasOne(fr => fr.Sender)
                .WithMany()
                .HasForeignKey(fr => fr.sender_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FriendRequest>()
                .HasOne(fr => fr.Receiver)
                .WithMany()
                .HasForeignKey(fr => fr.receiver_id)
                .OnDelete(DeleteBehavior.Restrict);
            
            //Notification constraints
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.SourceUser)
                .WithMany()
                .HasForeignKey(n => n.fromUserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.DestinationUser)
                .WithMany(u=> u.ReceivedNotifications)
                .HasForeignKey(n => n.toUserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
