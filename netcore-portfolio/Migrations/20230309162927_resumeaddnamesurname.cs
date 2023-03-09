using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_portfolio.Migrations
{
    public partial class resumeaddnamesurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Resume",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Resume",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "UserImage",
                table: "Resume");
        }
    }
}
