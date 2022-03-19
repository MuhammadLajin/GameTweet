using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameTweet.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tweet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tweet_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalReplies = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TweetId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Tweet_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reply_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 1, new DateTime(2022, 3, 19, 23, 37, 2, 618, DateTimeKind.Local).AddTicks(9207), "User 1" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 2, new DateTime(2022, 3, 19, 23, 37, 2, 622, DateTimeKind.Local).AddTicks(8311), "User 2" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 3, new DateTime(2022, 3, 19, 23, 37, 2, 622, DateTimeKind.Local).AddTicks(8691), "User 3" });

            migrationBuilder.InsertData(
                table: "Tweet",
                columns: new[] { "Id", "Content", "CreatedAt", "UserId" },
                values: new object[] { 1, "tweet 1 from user 1", new DateTime(2022, 3, 19, 23, 37, 2, 623, DateTimeKind.Local).AddTicks(7446), 1 });

            migrationBuilder.InsertData(
                table: "Tweet",
                columns: new[] { "Id", "Content", "CreatedAt", "UserId" },
                values: new object[] { 2, "tweet 2 from user 2", new DateTime(2022, 3, 19, 23, 37, 2, 623, DateTimeKind.Local).AddTicks(7957), 2 });

            migrationBuilder.InsertData(
                table: "Tweet",
                columns: new[] { "Id", "Content", "CreatedAt", "UserId" },
                values: new object[] { 3, "tweet 3 from user 3", new DateTime(2022, 3, 19, 23, 37, 2, 623, DateTimeKind.Local).AddTicks(8037), 3 });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Content", "CreatedAt", "TotalReplies", "TweetId", "UserId" },
                values: new object[] { 1, "comment 1 on tweet 1 from user 2", new DateTime(2022, 3, 19, 23, 37, 2, 625, DateTimeKind.Local).AddTicks(1486), 4, 1, 2 });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Content", "CreatedAt", "TweetId", "UserId" },
                values: new object[] { 2, "comment 2 on tweet 1 from user 3", new DateTime(2022, 3, 19, 23, 37, 2, 625, DateTimeKind.Local).AddTicks(2974), 1, 3 });

            migrationBuilder.InsertData(
                table: "Reply",
                columns: new[] { "Id", "CommentId", "Content", "CreatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "reply 1 on comment 1 from user 1", new DateTime(2022, 3, 19, 23, 37, 2, 626, DateTimeKind.Local).AddTicks(498), 1 },
                    { 2, 1, "reply 2 on comment 1 from user 2", new DateTime(2022, 3, 19, 23, 37, 2, 626, DateTimeKind.Local).AddTicks(884), 2 },
                    { 3, 1, "reply 3 on comment 1 from user 1", new DateTime(2022, 3, 19, 23, 37, 2, 626, DateTimeKind.Local).AddTicks(932), 1 },
                    { 4, 1, "reply 4 on comment 1 from user 3", new DateTime(2022, 3, 19, 23, 37, 2, 626, DateTimeKind.Local).AddTicks(965), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_TweetId",
                table: "Comment",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_CommentId",
                table: "Reply",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweet_UserId",
                table: "Tweet",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Tweet");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
