using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FriendsNetwork.PosgreSqlRepository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: true),
                    hashed_password = table.Column<string>(type: "text", nullable: true),
                    salt = table.Column<string>(type: "text", nullable: true),
                    online_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sender_id = table.Column<long>(type: "bigint", nullable: false),
                    receiver_id = table.Column<long>(type: "bigint", nullable: false),
                    accepted = table.Column<bool>(type: "boolean", nullable: false),
                    sentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.id);
                    table.CheckConstraint("CK_Request_NoSelfRequest", "sender_id <> receiver_id");
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_receiver_id",
                        column: x => x.receiver_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_sender_id",
                        column: x => x.sender_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    Userid = table.Column<long>(type: "bigint", nullable: false),
                    friend_id = table.Column<long>(type: "bigint", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.id);
                    table.CheckConstraint("CK_Friendship_NoSelfFriend", "user_id <> friend_id");
                    table.ForeignKey(
                        name: "FK_Friendships_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_friend_id",
                        column: x => x.friend_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_receiver_id",
                table: "FriendRequests",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_sender_id_receiver_id",
                table: "FriendRequests",
                columns: new[] { "sender_id", "receiver_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_friend_id",
                table: "Friendships",
                column: "friend_id");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_user_id_friend_id",
                table: "Friendships",
                columns: new[] { "user_id", "friend_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_Userid",
                table: "Friendships",
                column: "Userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
