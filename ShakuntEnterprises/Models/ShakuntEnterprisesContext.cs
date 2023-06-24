using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShakuntEnterprises.Models
{
    public partial class ShakuntEnterprisesContext : DbContext
    {
        //public ShakuntEnterprisesContext()
        //{
        //}

        public ShakuntEnterprisesContext(DbContextOptions<ShakuntEnterprisesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MainModuleBar> MainModuleBars { get; set; } = null!;
        public virtual DbSet<MainNavigationBar> MainNavigationBars { get; set; } = null!;
        public virtual DbSet<ModuleList> ModuleLists { get; set; } = null!;
        public virtual DbSet<NumberSeries> NumberSeries { get; set; } = null!;
        public virtual DbSet<UserMaster> UserMasters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainModuleBar>(entity =>
            {
                entity.ToTable("MainModuleBar");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.IsActive).HasMaxLength(1);

                entity.Property(e => e.ModuleName).HasMaxLength(150);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.UserRight).HasMaxLength(10);
            });

            modelBuilder.Entity<MainNavigationBar>(entity =>
            {
                entity.ToTable("MainNavigationBar");

                entity.Property(e => e.ActionName).HasMaxLength(100);

                entity.Property(e => e.ContollerName).HasMaxLength(100);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.IsActive).HasMaxLength(1);

                entity.Property(e => e.MenuName).HasMaxLength(150);

                entity.Property(e => e.ModuleName).HasMaxLength(150);

                entity.Property(e => e.SubMenuName).HasMaxLength(150);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.UserRight).HasMaxLength(10);
            });

            modelBuilder.Entity<ModuleList>(entity =>
            {
                entity.HasKey(e => e.ModuleId)
                    .HasName("PK__ModuleLi__2B7477A7E4333CEB");

                entity.ToTable("ModuleList");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.IsActive).HasMaxLength(1);

                entity.Property(e => e.ModuleName).HasMaxLength(150);

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.UserRight).HasMaxLength(10);
            });

            modelBuilder.Entity<NumberSeries>(entity =>
            {
                entity.HasKey(e => e.SeriesId)
                    .HasName("PK__NumberSe__F3A1C16113FFF9F0");

                entity.Property(e => e.SeriesId).HasMaxLength(25);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.SeriesDescription).HasMaxLength(250);
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserMaster");

                entity.Property(e => e.UserId)
                    .HasMaxLength(20)
                    .HasColumnName("user_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Department)
                    .HasMaxLength(250)
                    .HasColumnName("department");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(100)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserRight)
                    .HasMaxLength(10)
                    .HasColumnName("user_right");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(20)
                    .HasColumnName("user_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
