using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JavaFlorist.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bouquet> Bouquet { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<OccBouquet> OccBouquet { get; set; }
        public virtual DbSet<Occasion> Occasion { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bouquet>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MeContent)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Occasion)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.OccasionId)
                    .HasConstraintName("FK_Message_Occcasion");
            });

            modelBuilder.Entity<OccBouquet>(entity =>
            {
                entity.ToTable("Occ_Bouquet");

                entity.HasOne(d => d.Bouquet)
                    .WithMany(p => p.OccBouquet)
                    .HasForeignKey(d => d.BouquetId)
                    .HasConstraintName("FK_Occ_Bouquet_Bouquet");

                entity.HasOne(d => d.Occasion)
                    .WithMany(p => p.OccBouquet)
                    .HasForeignKey(d => d.OccasionId)
                    .HasConstraintName("FK_Occ_Bouquet_Occcasion");
            });

            modelBuilder.Entity<Occasion>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Message)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentConfirm)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Payment)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivingTime)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Order_Account");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("Order_Detail");

                entity.HasOne(d => d.Bouquet)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.BouquetId)
                    .HasConstraintName("FK_Order_Detail_Bouquet");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Order_Detail_Order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
