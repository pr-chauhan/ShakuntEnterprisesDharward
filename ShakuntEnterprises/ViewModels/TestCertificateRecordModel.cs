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
        public decimal? Quanity { get; set; }
        [DisplayName("Invoice No.")]
        public string? InvoiceNo { get; set; }
        [DisplayName("Trade Designation")]
        public string? TradeDesignation { get; set; }
        [DisplayName("Size (MM)")]
        public string? Size { get; set; }
        [DisplayName("Barch No.")]
        public string? BarchNo { get; set; }
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
        public decimal? ElementMinC { get; set; }
        [DisplayName("MIN (Si%)")]
        public decimal? ElementMinSi { get; set; }
        [DisplayName("MIN (Mn%)")]
        public decimal? ElementMinMn { get; set; }
        [DisplayName("MIN (P%)")]
        public decimal? ElementMinP { get; set; }
        [DisplayName("MIN (S%)")]
        public decimal? ElementMinS { get; set; }
        [DisplayName("MIN (Ni%)")]
        public decimal? ElementMinNi { get; set; }
        [DisplayName("MIN (Cr%)")]
        public decimal? ElementMinCr { get; set; }
        [DisplayName("MIN (Mo%)")]
        public decimal? ElementMinMo { get; set; }
        [DisplayName("MIN (Cu%)")]
        public decimal? ElementMinCu { get; set; }
        [DisplayName("MAX (C%)")]
        public decimal? ElementMaxC { get; set; }
        [DisplayName("MAX (Si%)")]
        public decimal? ElementMaxSi { get; set; }
        [DisplayName("MAX (Mn%)")]
        public decimal? ElementMaxMn { get; set; }
        [DisplayName("MAX (P%)")]
        public decimal? ElementMaxP { get; set; }
        [DisplayName("MAX (S%)")]
        public decimal? ElementMaxS { get; set; }
        [DisplayName("MAX (Ni%)")]
        public decimal? ElementMaxNi { get; set; }
        [DisplayName("MAX (Cr%)")]
        public decimal? ElementMaxCr { get; set; }
        [DisplayName("MAX (Mo%)")]
        public decimal? ElementMaxMo { get; set; }
        [DisplayName("MAX (Cu%)")]
        public decimal? ElementMaxCu { get; set; }
        [DisplayName("MIN UTS (Mpa)")]
        public decimal? TestMinUts { get; set; }
        [DisplayName("MIN Y.S. (Mpa)")]
        public decimal? TestMinYs { get; set; }
        [DisplayName("MIN Elongation")]
        public decimal? TestMinElongation { get; set; }
        [DisplayName("MAX UTS (Mpa)")]
        public decimal? TestMaxUts { get; set; }
        [DisplayName("MAX Y.S. (Mpa)")]
        public decimal? TestMaxYs { get; set; }
        [DisplayName("MAX Elongation")]
        public decimal? TestMaxElongation { get; set; }
        [DisplayName("Test Temp. (C$)")]
        public string? TestTemp { get; set; }
        [DisplayName("Impact Value (J@ - 40C)")]
        public string? TestImpectValue { get; set; }
        [DisplayName("Test Condition")]
        public string? TestCondition { get; set; }
        public string? Remarks { get; set; }

        public string? CertificateType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
