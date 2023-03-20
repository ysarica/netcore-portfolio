using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_portfolio.Migrations
{
    public partial class migskilladd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillCategory",
                columns: table => new
                {
                    SCID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategory", x => x.SCID);
                    table.ForeignKey(
                        name: "FK_SkillCategory_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCID = table.Column<int>(type: "int", nullable: true),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillDegre = table.Column<int>(type: "int", nullable: true),
                    SkillCategorySCID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_Skill_SkillCategory_SkillCategorySCID",
                        column: x => x.SkillCategorySCID,
                        principalTable: "SkillCategory",
                        principalColumn: "SCID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillCategorySCID",
                table: "Skill",
                column: "SkillCategorySCID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillCategory_ResumeID",
                table: "SkillCategory",
                column: "ResumeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "SkillCategory");
        }
    }
}
