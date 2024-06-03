﻿// <auto-generated />
using System;
using C03_HeThongTimGiupViec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace C03_HeThongTimGiupViec.Migrations
{
    [DbContext(typeof(C03_HeThongTimGiupViecContext))]
    [Migration("20240603073002_Attribute")]
    partial class Attribute
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicture")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex(new[] { "Email" }, "UQ__Accounts__A9D10534B6EC2145")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Complaint", b =>
                {
                    b.Property<int>("ComplaintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ComplaintID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplaintId"), 1L, 1);

                    b.Property<string>("Attachments")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ComplaintAgainst")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ComplaintBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ComplaintDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("IsCorect")
                        .HasColumnType("bit");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("ComplaintId");

                    b.HasIndex("ComplaintAgainst");

                    b.HasIndex("ComplaintBy");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ContractID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractId"), 1L, 1);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("HandymanId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("HandymanID");

                    b.Property<int?>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("PostID");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ContractId");

                    b.HasIndex("HandymanId");

                    b.HasIndex("PostId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MessageID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("MessageText")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ReadOn")
                        .HasColumnType("datetime");

                    b.Property<string>("ReceiveByAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SentByAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("SentOn")
                        .HasColumnType("datetime");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiveByAccountId");

                    b.HasIndex("SentByAccountId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PaymentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int?>("ContractId")
                        .HasColumnType("int")
                        .HasColumnName("ContractID");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentId");

                    b.HasIndex("ContractId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PostID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("PostDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int")
                        .HasColumnName("ServiceID");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("PostId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReviewID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReviewDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ReviewedId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ReviewedID");

                    b.Property<string>("ReviewerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ReviewerID");

                    b.HasKey("ReviewId");

                    b.HasIndex("ReviewedId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ServiceID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Slide", b =>
                {
                    b.Property<int>("SlideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SlideId"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("Priority")
                        .HasColumnType("int");

                    b.HasKey("SlideId");

                    b.ToTable("Slides");
                });

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("UserService", b =>
                {
                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasColumnName("ServiceID");

                    b.HasKey("AccountId", "ServiceId")
                        .HasName("PK__UserServ__88CC1EA82E85EBFF");

                    b.HasIndex("ServiceId");

                    b.ToTable("UserServices", (string)null);
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Complaint", b =>
                {
                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", "ComplaintAgainstNavigation")
                        .WithMany("ComplaintComplaintAgainstNavigations")
                        .HasForeignKey("ComplaintAgainst")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK__Complaint__Compl__52593CB8");

                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", "ComplaintByNavigation")
                        .WithMany("ComplaintComplaintByNavigations")
                        .HasForeignKey("ComplaintBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK__Complaint__Compl__5165187F");

                    b.Navigation("ComplaintAgainstNavigation");

                    b.Navigation("ComplaintByNavigation");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Contract", b =>
                {
                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", "Handyman")
                        .WithMany("Contracts")
                        .HasForeignKey("HandymanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Contracts__Handy__47DBAE45");

                    b.HasOne("C03_HeThongTimGiupViec.Models.Post", "Post")
                        .WithMany("Contracts")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK__Contracts__PostI__46E78A0C");

                    b.Navigation("Handyman");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Message", b =>
                {
                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", "ReceiveByAccount")
                        .WithMany("MessageReceiveByAccounts")
                        .HasForeignKey("ReceiveByAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK__Messages__Receiv__5812160E");

                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", "SentByAccount")
                        .WithMany("MessageSentByAccounts")
                        .HasForeignKey("SentByAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK__Messages__SentBy__571DF1D5");

                    b.Navigation("ReceiveByAccount");

                    b.Navigation("SentByAccount");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Payment", b =>
                {
                    b.HasOne("C03_HeThongTimGiupViec.Models.Contract", "Contract")
                        .WithMany("Payments")
                        .HasForeignKey("ContractId")
                        .HasConstraintName("FK__Payments__Contra__4AB81AF0");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Post", b =>
                {
                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", "Account")
                        .WithMany("Posts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Posts__AccountId__4316F928");

                    b.HasOne("C03_HeThongTimGiupViec.Models.Service", "Service")
                        .WithMany("Posts")
                        .HasForeignKey("ServiceId")
                        .HasConstraintName("FK__Posts__ServiceID__440B1D61");

                    b.Navigation("Account");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Review", b =>
                {
                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", "Reviewed")
                        .WithMany("ReviewRevieweds")
                        .HasForeignKey("ReviewedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Reviews__Reviewe__4E88ABD4");

                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", "Reviewer")
                        .WithMany("ReviewReviewers")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK__Reviews__Reviewe__4D94879B");

                    b.Navigation("Reviewed");

                    b.Navigation("Reviewer");
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
                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", null)
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

                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserService", b =>
                {
                    b.HasOne("C03_HeThongTimGiupViec.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK__UserServi__Accou__3F466844");

                    b.HasOne("C03_HeThongTimGiupViec.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .IsRequired()
                        .HasConstraintName("FK__UserServi__Servi__403A8C7D");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Account", b =>
                {
                    b.Navigation("ComplaintComplaintAgainstNavigations");

                    b.Navigation("ComplaintComplaintByNavigations");

                    b.Navigation("Contracts");

                    b.Navigation("MessageReceiveByAccounts");

                    b.Navigation("MessageSentByAccounts");

                    b.Navigation("Posts");

                    b.Navigation("ReviewRevieweds");

                    b.Navigation("ReviewReviewers");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Contract", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Post", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("C03_HeThongTimGiupViec.Models.Service", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
