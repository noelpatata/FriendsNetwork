using Microsoft.EntityFrameworkCore;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.SqlRepository.Contexts
{
    public class FriendsDbContext : DbContext
    {
        public FriendsDbContext(DbContextOptions<FriendsDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FriendShip> Friendships { get; set; }

        // Mapear entidades manualmente si lo prefieres:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //friend class constraints
            modelBuilder.Entity<FriendShip>()
                .HasIndex(f => new { f.user_id, f.friend_id })
                .IsUnique();

            modelBuilder.Entity<FriendShip>()
                .ToTable(t => t.HasCheckConstraint("CK_Friendship_NoSelfFriend", "user_id <> friend_id"));

            modelBuilder.Entity<FriendShip>()
                .HasOne(f => f.Friend)
                .WithMany(u => u.FriendsOf)
                .HasForeignKey(f => f.friend_id)
                .OnDelete(DeleteBehavior.Cascade);

            // FriendRequestClass constraints
            //modelBuilder.Entity<FriendRequestClass>()
            //    .HasIndex(f => new { f.sender_id, f.receiver_id })
            //    .IsUnique(); // Prevent duplicate requests

            //modelBuilder.Entity<FriendRequestClass>()
            //    .ToTable(t => t.HasCheckConstraint("CK_Request_NoSelfRequest", "sender_id <> receiver_id"));

            //modelBuilder.Entity<FriendRequestClass>()
            //    .HasOne(fr => fr.Sender)
            //    .WithMany()
            //    .HasForeignKey(fr => fr.sender_id)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<FriendRequestClass>()
            //    .HasOne(fr => fr.Receiver)
            //    .WithMany()
            //    .HasForeignKey(fr => fr.receiver_id)
            //    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
