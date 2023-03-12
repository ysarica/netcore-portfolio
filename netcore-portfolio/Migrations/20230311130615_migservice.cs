using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_portfolio.Migrations
{
    public partial class migservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceImage",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceImage",
                table: "Service");
        }
    }
}
