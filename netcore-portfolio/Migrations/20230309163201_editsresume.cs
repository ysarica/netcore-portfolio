using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_portfolio.Migrations
{
    public partial class editsresume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImage",
                table: "Resume");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
