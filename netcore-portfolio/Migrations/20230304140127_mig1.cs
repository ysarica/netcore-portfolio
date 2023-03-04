using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_portfolio.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogCategory",
                columns: table => new
                {
                    BlogCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogCategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BlogCategoryState = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategory", x => x.BlogCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ContactMessage",
                columns: table => new
                {
                    CMID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessage", x => x.CMID);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioCategory",
                columns: table => new
                {
                    PCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PCategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioCategory", x => x.PCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "SocialAccounts",
                columns: table => new
                {
                    SocialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SocialLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialIcon = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SocialState = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialAccounts", x => x.SocialID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TitleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteSettings",
                columns: table => new
                {
                    WSID = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Font = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Music = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MusicAutoPlay = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteSettings", x => x.WSID);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogCategoryID = table.Column<int>(type: "int", nullable: true),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BlogDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BlogDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogState = table.Column<bool>(type: "bit", nullable: true),
                    BlogImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_Blog_BlogCategory_BlogCategoryID",
                        column: x => x.BlogCategoryID,
                        principalTable: "BlogCategory",
                        principalColumn: "BlogCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    PID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PCategoryID = table.Column<int>(type: "int", nullable: true),
                    PType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PFactoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PDeliveryDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PUseService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioCategoryPCategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.PID);
                    table.ForeignKey(
                        name: "FK_Portfolio_PortfolioCategory_PortfolioCategoryPCategoryID",
                        column: x => x.PortfolioCategoryPCategoryID,
                        principalTable: "PortfolioCategory",
                        principalColumn: "PCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    ResumeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ResumeImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeAbout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdfCV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkState = table.Column<bool>(type: "bit", nullable: true),
                    ServiceState = table.Column<bool>(type: "bit", nullable: true),
                    WorkProccesState = table.Column<bool>(type: "bit", nullable: true),
                    WorkPartnersState = table.Column<bool>(type: "bit", nullable: true),
                    HobbiesState = table.Column<bool>(type: "bit", nullable: true),
                    WorkHistoryState = table.Column<bool>(type: "bit", nullable: true),
                    EducationState = table.Column<bool>(type: "bit", nullable: true),
                    TestimonialState = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.ResumeID);
                    table.ForeignKey(
                        name: "FK_Resume_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogComment",
                columns: table => new
                {
                    BlogCommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogID = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Confirmed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComment", x => x.BlogCommentID);
                    table.ForeignKey(
                        name: "FK_BlogComment_Blog_BlogID",
                        column: x => x.BlogID,
                        principalTable: "Blog",
                        principalColumn: "BlogID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioImage",
                columns: table => new
                {
                    PImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PID = table.Column<int>(type: "int", nullable: true),
                    PortfolioPID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioImage", x => x.PImageID);
                    table.ForeignKey(
                        name: "FK_PortfolioImage_Portfolio_PortfolioPID",
                        column: x => x.PortfolioPID,
                        principalTable: "Portfolio",
                        principalColumn: "PID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    EducationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FinishDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EducationBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.EducationID);
                    table.ForeignKey(
                        name: "FK_Education_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    HobbieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeID = table.Column<int>(type: "int", nullable: true),
                    HobbieName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HobbieImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.HobbieID);
                    table.ForeignKey(
                        name: "FK_Hobbies_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeID = table.Column<int>(type: "int", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Service_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    TestimonialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeID = table.Column<int>(type: "int", nullable: true),
                    TName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TCoımpany = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.TestimonialID);
                    table.ForeignKey(
                        name: "FK_Testimonials_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistory",
                columns: table => new
                {
                    WorkHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FinishDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WorkTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistory", x => x.WorkHistoryID);
                    table.ForeignKey(
                        name: "FK_WorkHistory_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkPartners",
                columns: table => new
                {
                    WorkPartnersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeID = table.Column<int>(type: "int", nullable: true),
                    WpsLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WpsName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPartners", x => x.WorkPartnersID);
                    table.ForeignKey(
                        name: "FK_WorkPartners_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkProces",
                columns: table => new
                {
                    WorkProcesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeID = table.Column<int>(type: "int", nullable: true),
                    WpOrder = table.Column<int>(type: "int", nullable: true),
                    WpName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    WpImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProces", x => x.WorkProcesID);
                    table.ForeignKey(
                        name: "FK_WorkProces_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_BlogCategoryID",
                table: "Blog",
                column: "BlogCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComment_BlogID",
                table: "BlogComment",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_Education_ResumeID",
                table: "Education",
                column: "ResumeID");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_ResumeID",
                table: "Hobbies",
                column: "ResumeID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_PortfolioCategoryPCategoryID",
                table: "Portfolio",
                column: "PortfolioCategoryPCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioImage_PortfolioPID",
                table: "PortfolioImage",
                column: "PortfolioPID");

            migrationBuilder.CreateIndex(
                name: "IX_Resume_UserID",
                table: "Resume",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ResumeID",
                table: "Service",
                column: "ResumeID");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_ResumeID",
                table: "Testimonials",
                column: "ResumeID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistory_ResumeID",
                table: "WorkHistory",
                column: "ResumeID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPartners_ResumeID",
                table: "WorkPartners",
                column: "ResumeID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkProces_ResumeID",
                table: "WorkProces",
                column: "ResumeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogComment");

            migrationBuilder.DropTable(
                name: "ContactMessage");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "PortfolioImage");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "SocialAccounts");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "WebsiteSettings");

            migrationBuilder.DropTable(
                name: "WorkHistory");

            migrationBuilder.DropTable(
                name: "WorkPartners");

            migrationBuilder.DropTable(
                name: "WorkProces");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropTable(
                name: "BlogCategory");

            migrationBuilder.DropTable(
                name: "PortfolioCategory");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
