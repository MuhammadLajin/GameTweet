using Microsoft.EntityFrameworkCore.Migrations;

namespace GameTweet.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tweet",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reply",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Comment",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tweet",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reply",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comment",
                newName: "id");
        }
    }
}
