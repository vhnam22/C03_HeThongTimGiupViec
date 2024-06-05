using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace C03_HeThongTimGiupViec.Models
{
    public partial class C03_HeThongTimGiupViecContext : IdentityDbContext<Account>
    {
        public C03_HeThongTimGiupViecContext()
        {
        }

        public C03_HeThongTimGiupViecContext(DbContextOptions<C03_HeThongTimGiupViecContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Complaint> Complaints { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Slide> Slides { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json")
                      .Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("SqlConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Accounts__A9D10534B6EC2145")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("integer");

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasMany(d => d.Services)
                    .WithMany(p => p.Accounts)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserService",
                        l => l.HasOne<Service>().WithMany().HasForeignKey("ServiceId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserServi__Servi__403A8C7D"),
                        r => r.HasOne<Account>().WithMany().HasForeignKey("AccountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserServi__Accou__3F466844"),
                        j =>
                        {
                            j.HasKey("AccountId", "ServiceId").HasName("PK__UserServ__88CC1EA82E85EBFF");

                            j.ToTable("UserServices");

                            j.IndexerProperty<int>("ServiceId").HasColumnName("ServiceID");
                        });
            });

            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.Property(e => e.ComplaintId).HasColumnName("ComplaintID");

                entity.Property(e => e.Attachments).HasMaxLength(255);

                entity.Property(e => e.ComplaintDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                .HasColumnType("NVARCHAR(MAX)")
                .IsUnicode(true);

                entity.HasOne(d => d.ResponseComplaint)
                      .WithMany()
                      .HasForeignKey(d => d.ResponseComplaintId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("FK_Complaint_ResponseComplaint");

                entity.HasOne(d => d.ComplaintAgainstNavigation)
                    .WithMany(p => p.ComplaintComplaintAgainstNavigations)
                    .HasForeignKey(d => d.ComplaintAgainst)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__Complaint__Compl__52593CB8");

                entity.HasOne(d => d.ComplaintByNavigation)
                    .WithMany(p => p.ComplaintComplaintByNavigations)
                    .HasForeignKey(d => d.ComplaintBy)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__Complaint__Compl__5165187F");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.HandymanId).HasColumnName("HandymanID");

                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnType("integer");

                entity.HasOne(d => d.Handyman)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.HandymanId)
                    .HasConstraintName("FK__Contracts__Handy__47DBAE45");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Contracts__PostI__46E78A0C");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.MessageText)
                .HasColumnType("NVARCHAR(MAX)")
                .IsUnicode(true);

                entity.Property(e => e.ReadOn).HasColumnType("datetime");

                entity.Property(e => e.SentOn).HasColumnType("datetime");

                entity.HasOne(d => d.ReceiveByAccount)
                    .WithMany(p => p.MessageReceiveByAccounts)
                    .HasForeignKey(d => d.ReceiveByAccountId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__Messages__Receiv__5812160E");

                entity.HasOne(d => d.SentByAccount)
                    .WithMany(p => p.MessageSentByAccounts)
                    .HasForeignKey(d => d.SentByAccountId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__Messages__SentBy__571DF1D5");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK__Payments__Contra__4AB81AF0");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.Description)
                .HasColumnType("NVARCHAR(MAX)")
                .IsUnicode(true);

                entity.Property(e => e.PostDate).HasColumnType("datetime");
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Status).HasColumnType("integer");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Posts__AccountId__4316F928");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Posts__ServiceID__440B1D61");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.Comment)
                .HasColumnType("NVARCHAR(MAX)")
                .IsUnicode(true);

                entity.Property(e => e.ReviewDate).HasColumnType("datetime");

                entity.Property(e => e.ReviewedId).HasColumnName("ReviewedID");

                entity.Property(e => e.ReviewerId).HasColumnName("ReviewerID");

                entity.HasOne(d => d.Reviewed)
                    .WithMany(p => p.ReviewRevieweds)
                    .HasForeignKey(d => d.ReviewedId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reviews__Reviewe__4E88ABD4");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.ReviewReviewers)
                    .HasForeignKey(d => d.ReviewerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK__Reviews__Reviewe__4D94879B");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Description)
                .HasColumnType("NVARCHAR(MAX)")
                .IsUnicode(true);

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(255)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
