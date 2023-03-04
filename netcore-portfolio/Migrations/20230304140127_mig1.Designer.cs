﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using netcore_portfolio.Models;

namespace netcore_portfolio.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230304140127_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("netcore_portfolio.Models.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

                    b.Property<bool?>("EducationState")
                        .HasColumnType("bit");

                    b.Property<bool?>("HobbiesState")
                        .HasColumnType("bit");

                    b.Property<string>("PdfCV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumeAbout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumeImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ServiceState")
                        .HasColumnType("bit");

                    b.Property<bool?>("TestimonialState")
                        .HasColumnType("bit");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<bool?>("WorkHistoryState")
                        .HasColumnType("bit");

                    b.Property<bool?>("WorkPartnersState")
                        .HasColumnType("bit");

                    b.Property<bool?>("WorkProccesState")
                        .HasColumnType("bit");

                    b.Property<bool?>("WorkState")
                        .HasColumnType("bit");

                    b.HasKey("ResumeID");

                    b.HasIndex("UserID");

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("netcore_portfolio.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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

            modelBuilder.Entity("netcore_portfolio.Models.SocialAccounts", b =>
                {
                    b.Property<int>("SocialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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

            modelBuilder.Entity("netcore_portfolio.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TitleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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

            modelBuilder.Entity("netcore_portfolio.Models.Resume", b =>
                {
                    b.HasOne("netcore_portfolio.Models.User", "User")
                        .WithMany("Resume")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
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

            modelBuilder.Entity("netcore_portfolio.Models.User", b =>
                {
                    b.Navigation("Resume");
                });
#pragma warning restore 612, 618
        }
    }
}