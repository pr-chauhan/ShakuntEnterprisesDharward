using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShakuntEnterprises.Models
{
    public partial class ShakuntEnterprisesContext : DbContext
    {
        public ShakuntEnterprisesContext()
        {
        }

        public ShakuntEnterprisesContext(DbContextOptions<ShakuntEnterprisesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MainModuleBar> MainModuleBars { get; set; } = null!;
        public virtual DbSet<MainNavigationBar> MainNavigationBars { get; set; } = null!;
        public virtual DbSet<ModuleList> ModuleLists { get; set; } = null!;
        public virtual DbSet<NumberSeries> NumberSeries { get; set; } = null!;
        public virtual DbSet<TestCertificateRecord> TestCertificateRecords { get; set; } = null!;
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
                    .HasName("PK__ModuleLi__2B7477A71D37FAE1");

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

            modelBuilder.Entity<TestCertificateRecord>(entity =>
            {
                entity.ToTable("TestCertificateRecord");

                entity.Property(e => e.Apms)
                    .HasMaxLength(50)
                    .HasColumnName("APMS");

                entity.Property(e => e.BarchNo).HasMaxLength(50);

                entity.Property(e => e.BaseMetal).HasMaxLength(50);

                entity.Property(e => e.CertificateNo).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.CurrentPolarity).HasMaxLength(50);

                entity.Property(e => e.CustomerName).HasMaxLength(150);

                entity.Property(e => e.ElementMaxC)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MAX_C");

                entity.Property(e => e.ElementMaxCr)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MAX_CR");

                entity.Property(e => e.ElementMaxCu)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MAX_CU");

                entity.Property(e => e.ElementMaxMn)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MAX_MN");

                entity.Property(e => e.ElementMaxMo)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MAX_MO");

                entity.Property(e => e.ElementMaxNi)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MAX_NI");

                entity.Property(e => e.ElementMaxP)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MAX_P");

                entity.Property(e => e.ElementMaxS)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MAX_S");

                entity.Property(e => e.ElementMaxSi)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MAX_SI");

                entity.Property(e => e.ElementMinC)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MIN_C");

                entity.Property(e => e.ElementMinCr)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MIN_CR");

                entity.Property(e => e.ElementMinCu)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MIN_CU");

                entity.Property(e => e.ElementMinMn)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MIN_MN");

                entity.Property(e => e.ElementMinMo)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MIN_MO");

                entity.Property(e => e.ElementMinNi)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MIN_NI");

                entity.Property(e => e.ElementMinP)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MIN_P");

                entity.Property(e => e.ElementMinS)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MIN_S");

                entity.Property(e => e.ElementMinSi)
                    .HasMaxLength(50)
                    .HasColumnName("Element_MIN_SI");

                entity.Property(e => e.FlowRate).HasMaxLength(50);

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.ManufecturingDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.PreHeatInerpassTemp).HasMaxLength(50);

                entity.Property(e => e.Quanity).HasColumnType("numeric(10, 3)");

                entity.Property(e => e.Remarks).HasMaxLength(1000);

                entity.Property(e => e.ShieldingGas).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.Specification).HasMaxLength(50);

                entity.Property(e => e.TestCondition)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Condition");

                entity.Property(e => e.TestImpectValue)
                    .HasMaxLength(50)
                    .HasColumnName("Test_ImpectValue");

                entity.Property(e => e.TestMaxElongation)
                    .HasMaxLength(50)
                    .HasColumnName("Test_MAX_Elongation");

                entity.Property(e => e.TestMaxUts)
                    .HasMaxLength(50)
                    .HasColumnName("Test_MAX_UTS");

                entity.Property(e => e.TestMaxYs)
                    .HasMaxLength(50)
                    .HasColumnName("Test_MAX_YS");

                entity.Property(e => e.TestMinElongation)
                    .HasMaxLength(50)
                    .HasColumnName("Test_MIN_Elongation");

                entity.Property(e => e.TestMinUts)
                    .HasMaxLength(50)
                    .HasColumnName("Test_MIN_UTS");

                entity.Property(e => e.TestMinYs)
                    .HasMaxLength(50)
                    .HasColumnName("Test_MIN_YS");

                entity.Property(e => e.TestTemp)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Temp");

                entity.Property(e => e.TradeDesignation).HasMaxLength(100);

                entity.Property(e => e.TravelSpeed).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Volts).HasMaxLength(50);

                entity.Property(e => e.WeldingProcess).HasMaxLength(50);
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
