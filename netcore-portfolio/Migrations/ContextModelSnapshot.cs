﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using netcore_portfolio.Models;

namespace netcore_portfolio.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("netcore_portfolio.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlogCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("BlogDate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BlogDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("BlogState")
                        .HasColumnType("bit");

                    b.Property<string>("BlogTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BlogID");

                    b.HasIndex("BlogCategoryID");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("netcore_portfolio.Models.BlogCategory", b =>
                {
                    b.Property<int>("BlogCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogCategoryName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool?>("BlogCategoryState")
                        .HasColumnType("bit");

                    b.HasKey("BlogCategoryID");

                    b.ToTable("BlogCategory");
                });

            modelBuilder.Entity("netcore_portfolio.Models.BlogComment", b =>
                {
                    b.Property<int>("BlogCommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlogID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<string>("DateTime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Website")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("BlogCommentID");

                    b.HasIndex("BlogID");

                    b.ToTable("BlogComment");
                });

            modelBuilder.Entity("netcore_portfolio.Models.ContactMessage", b =>
                {
                    b.Property<int>("CMID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateTime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CMID");

                    b.ToTable("ContactMessage");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Education", b =>
                {
                    b.Property<int>("EducationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EducationBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinishDate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ResumeID")
                        .HasColumnType("int");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EducationID");

                    b.HasIndex("ResumeID");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Hobbies", b =>
                {
                    b.Property<int>("HobbieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HobbieImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HobbieName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("ResumeID")
                        .HasColumnType("int");

                    b.HasKey("HobbieID");

                    b.HasIndex("ResumeID");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Portfolio", b =>
                {
                    b.Property<int>("PID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("PDeliveryDate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PFactoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PUseService")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PortfolioCategoryPCategoryID")
                        .HasColumnType("int");

                    b.HasKey("PID");

                    b.HasIndex("PortfolioCategoryPCategoryID");

                    b.ToTable("Portfolio");
                });

            modelBuilder.Entity("netcore_portfolio.Models.PortfolioCategory", b =>
                {
                    b.Property<int>("PCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PCategoryName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("PCategoryID");

                    b.ToTable("PortfolioCategory");
                });

            modelBuilder.Entity("netcore_portfolio.Models.PortfolioImage", b =>
                {
                    b.Property<int>("PImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PID")
                        .HasColumnType("int");

                    b.Property<string>("PImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PortfolioPID")
                        .HasColumnType("int");

                    b.HasKey("PImageID");

                    b.HasIndex("PortfolioPID");

                    b.ToTable("PortfolioImage");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Resume", b =>
                {
                    b.Property<int>("ResumeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("EducationState")
                        .HasColumnType("bit");

                    b.Property<bool?>("HobbiesState")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PdfCV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ResumeAbout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumeImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ServiceState")
                        .HasColumnType("bit");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("TestimonialState")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TitleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("WorkHistoryState")
                        .HasColumnType("bit");

                    b.Property<bool?>("WorkPartnersState")
                        .HasColumnType("bit");

                    b.Property<bool?>("WorkProccesState")
                        .HasColumnType("bit");

                    b.Property<bool?>("WorkState")
                        .HasColumnType("bit");

                    b.HasKey("ResumeID");

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ResumeID")
                        .HasColumnType("int");

                    b.Property<string>("ServiceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ServiceID");

                    b.HasIndex("ResumeID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("netcore_portfolio.Models.SmtpConfigs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EnableSSL")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<string>("Server")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SmtpConfigs");
                });

            modelBuilder.Entity("netcore_portfolio.Models.SocialAccounts", b =>
                {
                    b.Property<int>("SocialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SocialIcon")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SocialLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool?>("SocialState")
                        .HasColumnType("bit");

                    b.HasKey("SocialID");

                    b.ToTable("SocialAccounts");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Testimonials", b =>
                {
                    b.Property<int>("TestimonialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ResumeID")
                        .HasColumnType("int");

                    b.Property<string>("TCoımpany")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("TestimonialID");

                    b.HasIndex("ResumeID");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("netcore_portfolio.Models.WebsiteSettings", b =>
                {
                    b.Property<int>("WSID")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Font")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Music")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool?>("MusicAutoPlay")
                        .HasColumnType("bit");

                    b.HasKey("WSID");

                    b.ToTable("WebsiteSettings");
                });

            modelBuilder.Entity("netcore_portfolio.Models.WorkHistory", b =>
                {
                    b.Property<int>("WorkHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FinishDate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ResumeID")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WorkDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkTitle")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("WorkHistoryID");

                    b.HasIndex("ResumeID");

                    b.ToTable("WorkHistory");
                });

            modelBuilder.Entity("netcore_portfolio.Models.WorkPartners", b =>
                {
                    b.Property<int>("WorkPartnersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ResumeID")
                        .HasColumnType("int");

                    b.Property<string>("WpsLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WpsName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("WorkPartnersID");

                    b.HasIndex("ResumeID");

                    b.ToTable("WorkPartners");
                });

            modelBuilder.Entity("netcore_portfolio.Models.WorkProces", b =>
                {
                    b.Property<int>("WorkProcesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ResumeID")
                        .HasColumnType("int");

                    b.Property<string>("WpImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WpName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("WpOrder")
                        .HasColumnType("int");

                    b.HasKey("WorkProcesID");

                    b.HasIndex("ResumeID");

                    b.ToTable("WorkProces");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("netcore_portfolio.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("netcore_portfolio.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("netcore_portfolio.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("netcore_portfolio.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("netcore_portfolio.Models.Blog", b =>
                {
                    b.HasOne("netcore_portfolio.Models.BlogCategory", "BlogCategory")
                        .WithMany("Blog")
                        .HasForeignKey("BlogCategoryID");

                    b.Navigation("BlogCategory");
                });

            modelBuilder.Entity("netcore_portfolio.Models.BlogComment", b =>
                {
                    b.HasOne("netcore_portfolio.Models.Blog", "Blog")
                        .WithMany("BlogComment")
                        .HasForeignKey("BlogID");

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Education", b =>
                {
                    b.HasOne("netcore_portfolio.Models.Resume", "Resume")
                        .WithMany("Education")
                        .HasForeignKey("ResumeID");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Hobbies", b =>
                {
                    b.HasOne("netcore_portfolio.Models.Resume", "Resume")
                        .WithMany("Hobbies")
                        .HasForeignKey("ResumeID");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Portfolio", b =>
                {
                    b.HasOne("netcore_portfolio.Models.PortfolioCategory", "PortfolioCategory")
                        .WithMany("Portfolio")
                        .HasForeignKey("PortfolioCategoryPCategoryID");

                    b.Navigation("PortfolioCategory");
                });

            modelBuilder.Entity("netcore_portfolio.Models.PortfolioImage", b =>
                {
                    b.HasOne("netcore_portfolio.Models.Portfolio", "Portfolio")
                        .WithMany("PortfolioImage")
                        .HasForeignKey("PortfolioPID");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Service", b =>
                {
                    b.HasOne("netcore_portfolio.Models.Resume", "Resume")
                        .WithMany("Service")
                        .HasForeignKey("ResumeID");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Testimonials", b =>
                {
                    b.HasOne("netcore_portfolio.Models.Resume", "Resume")
                        .WithMany("Testimonials")
                        .HasForeignKey("ResumeID");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("netcore_portfolio.Models.WorkHistory", b =>
                {
                    b.HasOne("netcore_portfolio.Models.Resume", "Resume")
                        .WithMany("WorkHistory")
                        .HasForeignKey("ResumeID");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("netcore_portfolio.Models.WorkPartners", b =>
                {
                    b.HasOne("netcore_portfolio.Models.Resume", "Resume")
                        .WithMany("WorkPartners")
                        .HasForeignKey("ResumeID");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("netcore_portfolio.Models.WorkProces", b =>
                {
                    b.HasOne("netcore_portfolio.Models.Resume", "Resume")
                        .WithMany("WorkProces")
                        .HasForeignKey("ResumeID");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Blog", b =>
                {
                    b.Navigation("BlogComment");
                });

            modelBuilder.Entity("netcore_portfolio.Models.BlogCategory", b =>
                {
                    b.Navigation("Blog");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Portfolio", b =>
                {
                    b.Navigation("PortfolioImage");
                });

            modelBuilder.Entity("netcore_portfolio.Models.PortfolioCategory", b =>
                {
                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Resume", b =>
                {
                    b.Navigation("Education");

                    b.Navigation("Hobbies");

                    b.Navigation("Service");

                    b.Navigation("Testimonials");

                    b.Navigation("WorkHistory");

                    b.Navigation("WorkPartners");

                    b.Navigation("WorkProces");
                });
#pragma warning restore 612, 618
        }
    }
}
