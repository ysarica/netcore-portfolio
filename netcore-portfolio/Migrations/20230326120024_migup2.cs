using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_portfolio.Migrations
{
    public partial class migup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SkillCategoryState",
                table: "Resume",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillCategoryState",
                table: "Resume");
        }
    }
}
