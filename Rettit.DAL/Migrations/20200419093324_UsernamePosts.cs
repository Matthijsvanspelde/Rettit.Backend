using Microsoft.EntityFrameworkCore.Migrations;

namespace Rettit.DAL.Migrations
{
    public partial class UsernamePosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Post",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Post");
        }
    }
}
