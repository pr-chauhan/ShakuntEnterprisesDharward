using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ShakuntEnterprises.ViewModels
{
    public class TestCertificateRecordModel
    {
        public int Id { get; set; }
        [DisplayName("Certificate No.")]
        public string? CertificateNo { get; set; }
        [DisplayName("Customer Name")]
        public string? CustomerName { get; set; }
        [DisplayName("Issue Date")]
        public DateTime? IssueDate { get; set; }
        public string? Quanity { get; set; }
        [DisplayName("Invoice No.")]
        public string? InvoiceNo { get; set; }
        [DisplayName("Trade Designation")]
        public string? TradeDesignation { get; set; }
        [DisplayName("Size (MM)")]
        public string? Size { get; set; }
        [DisplayName("Batch Date")]
        public string? BatchDate { get; set; }
        [DisplayName("Batch No.")]
        public string? BatchNo { get; set; }
        [DisplayName("Manufecturing Date")]
        public DateTime? ManufecturingDate { get; set; }
        public string? Specification { get; set; }
        [DisplayName("Welding Process")]
        public string? WeldingProcess { get; set; }
        [DisplayName("Shielding Gas")]
        public string? ShieldingGas { get; set; }
        [DisplayName("Pre Heat Inerpass Temp.")]
        public string? PreHeatInerpassTemp { get; set; }
        public string? Type { get; set; }
        [DisplayName("Apms (A)")]
        public string? Apms { get; set; }
        [DisplayName("Flow Rate (LPM)")]
        public string? FlowRate { get; set; }
        [DisplayName("Current & Polarity")]
        public string? CurrentPolarity { get; set; }
        [DisplayName("Volts (V)")]
        public string? Volts { get; set; }
        [DisplayName("Travel Speed (MM/Min)")]
        public string? TravelSpeed { get; set; }
        [DisplayName("Base Metal")]
        public string? BaseMetal { get; set; }
        [DisplayName("MIN (C%)")]
        public string? ElementMinC { get; set; }
        [DisplayName("MIN (Si%)")]
        public string? ElementMinSi { get; set; }
        [DisplayName("MIN (Mn%)")]
        public string? ElementMinMn { get; set; }
        [DisplayName("MIN (P%)")]
        public string? ElementMinP { get; set; }
        [DisplayName("MIN (S%)")]
        public string? ElementMinS { get; set; }
        [DisplayName("MIN (Ni%)")]
        public string? ElementMinNi { get; set; }
        [DisplayName("MIN (Cr%)")]
        public string? ElementMinCr { get; set; }
        [DisplayName("MIN (Mo%)")]
        public string? ElementMinMo { get; set; }
        [DisplayName("MIN (Cu%)")]
        public string? ElementMinCu { get; set; }
        [DisplayName("MAX (C%)")]
        public string? ElementMaxC { get; set; }
        [DisplayName("MAX (Si%)")]
        public string? ElementMaxSi { get; set; }
        [DisplayName("MAX (Mn%)")]
        public string? ElementMaxMn { get; set; }
        [DisplayName("MAX (P%)")]
        public string? ElementMaxP { get; set; }
        [DisplayName("MAX (S%)")]
        public string? ElementMaxS { get; set; }
        [DisplayName("MAX (Ni%)")]
        public string? ElementMaxNi { get; set; }
        [DisplayName("MAX (Cr%)")]
        public string? ElementMaxCr { get; set; }
        [DisplayName("MAX (Mo%)")]
        public string? ElementMaxMo { get; set; }
        [DisplayName("MAX (Cu%)")]
        public string? ElementMaxCu { get; set; }

        [DisplayName("MIN.UTS.(Mpa)")]
        public string? TestMinUts { get; set; }
        [DisplayName("MIN Y.S.(Mpa)")]
        public string? TestMinYs { get; set; }
        [DisplayName("MIN.Elongation")]
        public string? TestMinElongation { get; set; }
        [DisplayName("MAX.UTS.(Mpa)")]
        public string? TestMaxUts { get; set; }
        [DisplayName("MAX.YS.(Mpa)")]
        public string? TestMaxYs { get; set; }
        [DisplayName("MAX.Elongation")]
        public string? TestMaxElongation { get; set; }

        [DisplayName("Test Temp.(C$)")]
        public string? TestTemp { get; set; }
        [DisplayName("Impact.Value(J@-40C)")]
        public string? TestImpectValue { get; set; }
        [DisplayName("Test Condition")]
        public string? TestCondition { get; set; }

        [DisplayName("Size Standard Value")]
        public string? SizeStandardValue { get; set; }
        [DisplayName("Size Actual Value")]
        public string? SizeActualValue { get; set; }
        [DisplayName("Coating Standard Value")]
        public string? CoatingStandardValue { get; set; }
        [DisplayName("Coating Actual Value")]
        public string? CoatingActualValue { get; set; }
        [DisplayName("Uts Wire Standard Value")]
        public string? UtswireStandardValue { get; set; }
        [DisplayName("Uts Wire Actual Value")]
        public string? UtswireActualValue { get; set; }
        [DisplayName("Cast Dia Standard Value")]
        public string? CastDiaStandardValue { get; set; }
        [DisplayName("Cast Dia Actual Value")]
        public string? CastDiaActualValue { get; set; }
        [DisplayName("Helix Standard Value")]
        public string? HelixStandardValue { get; set; }
        [DisplayName("Helix Actual Value")]
        public string? HelixActualValue { get; set; }
        [DisplayName("Other Test Radio Specs ")]
        public string? OtherTestRadioSpecs { get; set; }
        [DisplayName("Other Test Face Bend Specs")]
        public string? OtherTestFaceBendSpecs { get; set; }
        [DisplayName("Other Test Filled Specs")]
        public string? OtherTestFilledSpecs { get; set; }

        public string? Remarks { get; set; }

        public int? IsApproved { get; set; }

        public string? HideSection { get; set; }
        public string? CombineBatchNo { get; set; }

        public string? CertificateType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        [DisplayName("Show CE Logo")]
        public string? IsShowCelogo { get; set; }
        [DisplayName("Tally Item Name")]
        public string? TallyItemName { get; set; }
        [DisplayName("Grade Type")]
        public string? GradeType { get; set; }
        [DisplayName("Show Mig")]
        public string? IsShowMig { get; set; }
        [DisplayName("Show Flux")]
        public string? IsShowFlux { get; set; }
        [DisplayName("Show None")]
        public string? IsShowNone { get; set; }
        [DisplayName("Invoice Date")]
        public DateTime? InvoiceDate { get; set; }
    }
}
