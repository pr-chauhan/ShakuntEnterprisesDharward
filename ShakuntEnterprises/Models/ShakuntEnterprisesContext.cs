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

        public virtual DbSet<BatchMaster> BatchMasters { get; set; } = null!;
        public virtual DbSet<MainModuleBar> MainModuleBars { get; set; } = null!;
        public virtual DbSet<MainNavigationBar> MainNavigationBars { get; set; } = null!;
        public virtual DbSet<ModuleList> ModuleLists { get; set; } = null!;
        public virtual DbSet<NumberSeries> NumberSeries { get; set; } = null!;
        public virtual DbSet<SizeMaster> SizeMasters { get; set; } = null!;
        public virtual DbSet<TestCertificateRecord> TestCertificateRecords { get; set; } = null!;
        public virtual DbSet<TestCertificateRecordOld> TestCertificateRecordOlds { get; set; } = null!;
        public virtual DbSet<TestCertificateResultRecord> TestCertificateResultRecords { get; set; } = null!;
        public virtual DbSet<TradeDesignationGradeType> TradeDesignationGradeTypes { get; set; } = null!;
        public virtual DbSet<TradeDesignationMaster> TradeDesignationMasters { get; set; } = null!;
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
            modelBuilder.Entity<BatchMaster>(entity =>
            {
                entity.ToTable("BatchMaster");

                entity.Property(e => e.BatchNo).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.ElementResultC)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_C");

                entity.Property(e => e.ElementResultCr)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_CR");

                entity.Property(e => e.ElementResultCu)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_CU");

                entity.Property(e => e.ElementResultMn)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_MN");

                entity.Property(e => e.ElementResultMo)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_MO");

                entity.Property(e => e.ElementResultNi)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_NI");

                entity.Property(e => e.ElementResultP)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_P");

                entity.Property(e => e.ElementResultS)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_S");

                entity.Property(e => e.ElementResultSi)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_SI");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.OtherTestResultFaceBendSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTestResult_FaceBend_Specs");

                entity.Property(e => e.OtherTestResultFilledSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTestResult_Filled_Specs");

                entity.Property(e => e.OtherTestResultRadioSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTestResult_Radio_Specs");

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.TestResultCondition)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Result_Condition");

                entity.Property(e => e.TestResultElongation)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Result_Elongation");

                entity.Property(e => e.TestResultImpectValue)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Result_ImpectValue");

                entity.Property(e => e.TestResultNiCrMo)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Result_NI_CR_MO");

                entity.Property(e => e.TestResultTemp)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Result_Temp");

                entity.Property(e => e.TestResultUts)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Result_UTS");

                entity.Property(e => e.TestResultYs)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Result_YS");
            });

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
                    .HasName("PK__NumberSe__F3A1C161ACC87C1D");

                entity.Property(e => e.SeriesId).HasMaxLength(25);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.SeriesDescription).HasMaxLength(250);
            });

            modelBuilder.Entity<SizeMaster>(entity =>
            {
                entity.ToTable("SizeMaster");

                entity.Property(e => e.Apms)
                    .HasMaxLength(50)
                    .HasColumnName("APMS");

                entity.Property(e => e.CastDiaActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("CastDia_ActualValue");

                entity.Property(e => e.CastDiaStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("CastDia_StandardValue");

                entity.Property(e => e.CoatingActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("Coating_ActualValue");

                entity.Property(e => e.CoatingStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("Coating_StandardValue");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.HelixActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("Helix_ActualValue");

                entity.Property(e => e.HelixStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("Helix_StandardValue");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.SizeActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("Size_ActualValue");

                entity.Property(e => e.SizeStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("Size_StandardValue");

                entity.Property(e => e.TravelSpeed).HasMaxLength(50);

                entity.Property(e => e.UtswireActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("UTSWire_ActualValue");

                entity.Property(e => e.UtswireStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("UTSWire_StandardValue");

                entity.Property(e => e.Volts).HasMaxLength(50);
            });

            modelBuilder.Entity<TestCertificateRecord>(entity =>
            {
                entity.ToTable("TestCertificateRecord");

                entity.Property(e => e.Apms)
                    .HasMaxLength(50)
                    .HasColumnName("APMS");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Approved_By");

                entity.Property(e => e.ApprovedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Approved_Date");

                entity.Property(e => e.BaseMetal).HasMaxLength(50);

                entity.Property(e => e.BatchDate).HasMaxLength(50);

                entity.Property(e => e.BatchNo).HasMaxLength(50);

                entity.Property(e => e.CancelBy).HasMaxLength(20);

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.CastDiaActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("CastDia_ActualValue");

                entity.Property(e => e.CastDiaStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("CastDia_StandardValue");

                entity.Property(e => e.CertificateNo).HasMaxLength(50);

                entity.Property(e => e.CertificateType)
                    .HasMaxLength(50)
                    .HasColumnName("Certificate_Type");

                entity.Property(e => e.CoatingActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("Coating_ActualValue");

                entity.Property(e => e.CoatingStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("Coating_StandardValue");

                entity.Property(e => e.CombineBatchNo).HasMaxLength(100);

                entity.Property(e => e.CombineMfgdate)
                    .HasMaxLength(100)
                    .HasColumnName("CombineMFGDate");

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

                entity.Property(e => e.ElementMaxNicrmo)
                    .HasMaxLength(50)
                    .HasColumnName("ElementMAX_NICRMO");

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

                entity.Property(e => e.ElementMinNicrmo)
                    .HasMaxLength(50)
                    .HasColumnName("ElementMIN_NICRMO");

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

                entity.Property(e => e.GradeType).HasMaxLength(50);

                entity.Property(e => e.HelixActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("Helix_ActualValue");

                entity.Property(e => e.HelixStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("Helix_StandardValue");

                entity.Property(e => e.HideSection).HasMaxLength(5);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.IsShowCelogo)
                    .HasMaxLength(3)
                    .HasColumnName("IsShowCELogo");

                entity.Property(e => e.IsShowElementNiCrMo)
                    .HasMaxLength(5)
                    .HasColumnName("isShowElementNiCrMo");

                entity.Property(e => e.IsShowFlux).HasMaxLength(3);

                entity.Property(e => e.IsShowMig).HasMaxLength(3);

                entity.Property(e => e.IsShowNone).HasMaxLength(3);

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.ManufecturingDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.OtherTestFaceBendSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTest_FaceBend_Specs");

                entity.Property(e => e.OtherTestFilledSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTest_Filled_Specs");

                entity.Property(e => e.OtherTestRadioSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTest_Radio_Specs");

                entity.Property(e => e.PreHeatInerpassTemp).HasMaxLength(50);

                entity.Property(e => e.Quanity).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(1000);

                entity.Property(e => e.ShieldingGas).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.SizeActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("Size_ActualValue");

                entity.Property(e => e.SizeStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("Size_StandardValue");

                entity.Property(e => e.Specification).HasMaxLength(50);

                entity.Property(e => e.TallyItemName)
                    .HasMaxLength(1000)
                    .HasColumnName("Tally_ItemName");

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

                entity.Property(e => e.UtswireActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("UTSWire_ActualValue");

                entity.Property(e => e.UtswireStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("UTSWire_StandardValue");

                entity.Property(e => e.Volts).HasMaxLength(50);

                entity.Property(e => e.WeldingProcess).HasMaxLength(50);
            });

            modelBuilder.Entity<TestCertificateRecordOld>(entity =>
            {
                entity.ToTable("TestCertificateRecord_Old");

                entity.Property(e => e.Apms)
                    .HasMaxLength(50)
                    .HasColumnName("APMS");

                entity.Property(e => e.BaseMetal).HasMaxLength(50);

                entity.Property(e => e.BatchDate).HasMaxLength(50);

                entity.Property(e => e.BatchNo).HasMaxLength(50);

                entity.Property(e => e.CastDiaActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("CastDia_ActualValue");

                entity.Property(e => e.CastDiaStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("CastDia_StandardValue");

                entity.Property(e => e.CertificateNo).HasMaxLength(50);

                entity.Property(e => e.CertificateType)
                    .HasMaxLength(50)
                    .HasColumnName("Certificate_Type");

                entity.Property(e => e.CoatingActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("Coating_ActualValue");

                entity.Property(e => e.CoatingStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("Coating_StandardValue");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.CurrentPolarity).HasMaxLength(50);

                entity.Property(e => e.CustomerName).HasMaxLength(150);

                entity.Property(e => e.ElementMaxC)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MAX_C");

                entity.Property(e => e.ElementMaxCr)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MAX_CR");

                entity.Property(e => e.ElementMaxCu)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MAX_CU");

                entity.Property(e => e.ElementMaxMn)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MAX_MN");

                entity.Property(e => e.ElementMaxMo)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MAX_MO");

                entity.Property(e => e.ElementMaxNi)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MAX_NI");

                entity.Property(e => e.ElementMaxP)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MAX_P");

                entity.Property(e => e.ElementMaxS)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MAX_S");

                entity.Property(e => e.ElementMaxSi)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MAX_SI");

                entity.Property(e => e.ElementMinC)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MIN_C");

                entity.Property(e => e.ElementMinCr)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MIN_CR");

                entity.Property(e => e.ElementMinCu)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MIN_CU");

                entity.Property(e => e.ElementMinMn)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MIN_MN");

                entity.Property(e => e.ElementMinMo)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MIN_MO");

                entity.Property(e => e.ElementMinNi)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MIN_NI");

                entity.Property(e => e.ElementMinP)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MIN_P");

                entity.Property(e => e.ElementMinS)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MIN_S");

                entity.Property(e => e.ElementMinSi)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_MIN_SI");

                entity.Property(e => e.ElementResultC)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_Result_C");

                entity.Property(e => e.ElementResultCr)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_Result_CR");

                entity.Property(e => e.ElementResultCu)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_Result_CU");

                entity.Property(e => e.ElementResultMn)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_Result_MN");

                entity.Property(e => e.ElementResultMo)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_Result_MO");

                entity.Property(e => e.ElementResultNi)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_Result_NI");

                entity.Property(e => e.ElementResultP)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_Result_P");

                entity.Property(e => e.ElementResultS)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_Result_S");

                entity.Property(e => e.ElementResultSi)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Element_Result_SI");

                entity.Property(e => e.FlowRate).HasMaxLength(50);

                entity.Property(e => e.HelixActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("Helix_ActualValue");

                entity.Property(e => e.HelixStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("Helix_StandardValue");

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.ManufecturingDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.OtherTestFaceBendSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTest_FaceBend_Specs");

                entity.Property(e => e.OtherTestFilledSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTest_Filled_Specs");

                entity.Property(e => e.OtherTestRadioSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTest_Radio_Specs");

                entity.Property(e => e.OtherTestResultFaceBendSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTestResult_FaceBend_Specs");

                entity.Property(e => e.OtherTestResultFilledSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTestResult_Filled_Specs");

                entity.Property(e => e.OtherTestResultRadioSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTestResult_Radio_Specs");

                entity.Property(e => e.PreHeatInerpassTemp).HasMaxLength(50);

                entity.Property(e => e.Quanity).HasColumnType("numeric(10, 3)");

                entity.Property(e => e.Remarks).HasMaxLength(1000);

                entity.Property(e => e.ShieldingGas).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.SizeActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("Size_ActualValue");

                entity.Property(e => e.SizeStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("Size_StandardValue");

                entity.Property(e => e.Specification).HasMaxLength(50);

                entity.Property(e => e.TestCondition)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Condition");

                entity.Property(e => e.TestImpectValue)
                    .HasMaxLength(50)
                    .HasColumnName("Test_ImpectValue");

                entity.Property(e => e.TestMaxElongation)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Test_MAX_Elongation");

                entity.Property(e => e.TestMaxUts)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Test_MAX_UTS");

                entity.Property(e => e.TestMaxYs)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Test_MAX_YS");

                entity.Property(e => e.TestMinElongation)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Test_MIN_Elongation");

                entity.Property(e => e.TestMinUts)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Test_MIN_UTS");

                entity.Property(e => e.TestMinYs)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Test_MIN_YS");

                entity.Property(e => e.TestResultElongation)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Test_Result_Elongation");

                entity.Property(e => e.TestResultUts)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Test_Result_UTS");

                entity.Property(e => e.TestResultYs)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("Test_Result_YS");

                entity.Property(e => e.TestTemp)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Temp");

                entity.Property(e => e.TradeDesignation).HasMaxLength(100);

                entity.Property(e => e.TravelSpeed).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UtswireActualValue)
                    .HasMaxLength(50)
                    .HasColumnName("UTSWire_ActualValue");

                entity.Property(e => e.UtswireStandardValue)
                    .HasMaxLength(50)
                    .HasColumnName("UTSWire_StandardValue");

                entity.Property(e => e.Volts).HasMaxLength(50);

                entity.Property(e => e.WeldingProcess).HasMaxLength(50);
            });

            modelBuilder.Entity<TestCertificateResultRecord>(entity =>
            {
                entity.ToTable("TestCertificateResultRecord");

                entity.Property(e => e.BatchDate).HasMaxLength(50);

                entity.Property(e => e.BatchNo).HasMaxLength(50);

                entity.Property(e => e.CertificateNo).HasMaxLength(50);

                entity.Property(e => e.CombineMfgdate)
                    .HasMaxLength(100)
                    .HasColumnName("CombineMFGDate");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.ElementResultC)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_C");

                entity.Property(e => e.ElementResultCr)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_CR");

                entity.Property(e => e.ElementResultCu)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_CU");

                entity.Property(e => e.ElementResultMn)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_MN");

                entity.Property(e => e.ElementResultMo)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_MO");

                entity.Property(e => e.ElementResultNi)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_NI");

                entity.Property(e => e.ElementResultNicrmo)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_NICRMO");

                entity.Property(e => e.ElementResultP)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_P");

                entity.Property(e => e.ElementResultS)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_S");

                entity.Property(e => e.ElementResultSi)
                    .HasMaxLength(50)
                    .HasColumnName("Element_Result_SI");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.OtherTestResultFaceBendSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTestResult_FaceBend_Specs");

                entity.Property(e => e.OtherTestResultFilledSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTestResult_Filled_Specs");

                entity.Property(e => e.OtherTestResultRadioSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTestResult_Radio_Specs");

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.TestCondition)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Condition");

                entity.Property(e => e.TestImpectValue)
                    .HasMaxLength(50)
                    .HasColumnName("Test_ImpectValue");

                entity.Property(e => e.TestResultElongation)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Result_Elongation");

                entity.Property(e => e.TestResultUts)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Result_UTS");

                entity.Property(e => e.TestResultYs)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Result_YS");

                entity.Property(e => e.TestTemp)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Temp");
            });

            modelBuilder.Entity<TradeDesignationGradeType>(entity =>
            {
                entity.ToTable("TradeDesignationGradeType");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.GradeType).HasMaxLength(10);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");
            });

            modelBuilder.Entity<TradeDesignationMaster>(entity =>
            {
                entity.ToTable("TradeDesignationMaster");

                entity.Property(e => e.BaseMetal).HasMaxLength(50);

                entity.Property(e => e.CompositionHeading).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.CurrentPolarity).HasMaxLength(50);

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

                entity.Property(e => e.GradeType).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.OtherTestFaceBendSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTest_FaceBend_Specs");

                entity.Property(e => e.OtherTestFilledSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTest_Filled_Specs");

                entity.Property(e => e.OtherTestRadioSpecs)
                    .HasMaxLength(50)
                    .HasColumnName("OtherTest_Radio_Specs");

                entity.Property(e => e.PreHeatInerpassTemp).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.ShieldingGas).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.Specification).HasMaxLength(200);

                entity.Property(e => e.TestCondition)
                    .HasMaxLength(50)
                    .HasColumnName("Test_Condition");

                entity.Property(e => e.TestImpectDegree)
                    .HasMaxLength(50)
                    .HasColumnName("Test_ImpectDegree");

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

                entity.Property(e => e.Type).HasMaxLength(50);

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
