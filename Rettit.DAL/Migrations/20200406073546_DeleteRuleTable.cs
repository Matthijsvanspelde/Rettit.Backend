using Microsoft.EntityFrameworkCore.Migrations;

namespace Rettit.DAL.Migrations
{
    public partial class DeleteRuleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubForumRule");

            migrationBuilder.AddColumn<string>(
                name: "Rule1",
                table: "SubForum",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rule2",
                table: "SubForum",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rule3",
                table: "SubForum",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rule1",
                table: "SubForum");

            migrationBuilder.DropColumn(
                name: "Rule2",
                table: "SubForum");

            migrationBuilder.DropColumn(
                name: "Rule3",
                table: "SubForum");

            migrationBuilder.CreateTable(
                name: "SubForumRule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubForumId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubForumRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubForumRule_SubForum_SubForumId",
                        column: x => x.SubForumId,
                        principalTable: "SubForum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubForumRule_SubForumId",
                table: "SubForumRule",
                column: "SubForumId");
        }
    }
}
