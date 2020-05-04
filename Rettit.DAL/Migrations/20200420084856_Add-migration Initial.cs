using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rettit.DAL.Migrations
{
    public partial class AddmigrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubForum",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    Rule1 = table.Column<string>(nullable: true),
                    Rule2 = table.Column<string>(nullable: true),
                    Rule3 = table.Column<string>(nullable: true),
                    UserIdId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubForum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubForum_User_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    SubForumIdId = table.Column<long>(nullable: true),
                    UserIdId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_SubForum_SubForumIdId",
                        column: x => x.SubForumIdId,
                        principalTable: "SubForum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_User_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    Posted = table.Column<DateTime>(nullable: false),
                    PostIdId = table.Column<long>(nullable: true),
                    UserIdId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostIdId",
                        column: x => x.PostIdId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostIdId",
                table: "Comment",
                column: "PostIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserIdId",
                table: "Comment",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SubForumIdId",
                table: "Post",
                column: "SubForumIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserIdId",
                table: "Post",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_SubForum_UserIdId",
                table: "SubForum",
                column: "UserIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "SubForum");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
