using System;
using System.Collections.Generic;

namespace ShakuntEnterprises.Models
{
    public partial class TestCertificateRecord
    {
        public int Id { get; set; }
        public string? CertificateNo { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? IssueDate { get; set; }
        public decimal? Quanity { get; set; }
        public string? InvoiceNo { get; set; }
        public string? TradeDesignation { get; set; }
        public string? Size { get; set; }
        public string? BatchDate { get; set; }
        public string? BarchNo { get; set; }
        public DateTime? ManufecturingDate { get; set; }
        public string? Specification { get; set; }
        public string? WeldingProcess { get; set; }
        public string? ShieldingGas { get; set; }
        public string? PreHeatInerpassTemp { get; set; }
        public string? Type { get; set; }
        public string? Apms { get; set; }
        public string? FlowRate { get; set; }
        public string? CurrentPolarity { get; set; }
        public string? Volts { get; set; }
        public string? TravelSpeed { get; set; }
        public string? BaseMetal { get; set; }
        public decimal? ElementMinC { get; set; }
        public decimal? ElementMinSi { get; set; }
        public decimal? ElementMinMn { get; set; }
        public decimal? ElementMinP { get; set; }
        public decimal? ElementMinS { get; set; }
        public decimal? ElementMinNi { get; set; }
        public decimal? ElementMinCr { get; set; }
        public decimal? ElementMinMo { get; set; }
        public decimal? ElementMinCu { get; set; }
        public decimal? ElementMaxC { get; set; }
        public decimal? ElementMaxSi { get; set; }
        public decimal? ElementMaxMn { get; set; }
        public decimal? ElementMaxP { get; set; }
        public decimal? ElementMaxS { get; set; }
        public decimal? ElementMaxNi { get; set; }
        public decimal? ElementMaxCr { get; set; }
        public decimal? ElementMaxMo { get; set; }
        public decimal? ElementMaxCu { get; set; }
        public decimal? ElementResultC { get; set; }
        public decimal? ElementResultSi { get; set; }
        public decimal? ElementResultMn { get; set; }
        public decimal? ElementResultP { get; set; }
        public decimal? ElementResultS { get; set; }
        public decimal? ElementResultNi { get; set; }
        public decimal? ElementResultCr { get; set; }
        public decimal? ElementResultMo { get; set; }
        public decimal? ElementResultCu { get; set; }
        public decimal? TestMinUts { get; set; }
        public decimal? TestMinYs { get; set; }
        public decimal? TestMinElongation { get; set; }
        public decimal? TestMaxUts { get; set; }
        public decimal? TestMaxYs { get; set; }
        public decimal? TestMaxElongation { get; set; }
        public decimal? TestResultUts { get; set; }
        public decimal? TestResultYs { get; set; }
        public decimal? TestResultElongation { get; set; }
        public string? TestTemp { get; set; }
        public string? TestImpectValue { get; set; }
        public string? TestCondition { get; set; }
        public string? SizeStandardValue { get; set; }
        public string? SizeActualValue { get; set; }
        public string? CoatingStandardValue { get; set; }
        public string? CoatingActualValue { get; set; }
        public string? UtswireStandardValue { get; set; }
        public string? UtswireActualValue { get; set; }
        public string? CastDiaStandardValue { get; set; }
        public string? CastDiaActualValue { get; set; }
        public string? HelixStandardValue { get; set; }
        public string? HelixActualValue { get; set; }
        public string? OtherTestRadioSpecs { get; set; }
        public string? OtherTestFaceBendSpecs { get; set; }
        public string? OtherTestFilletSpecs { get; set; }
        public string? OtherTestResultRadioSpecs { get; set; }
        public string? OtherTestResultFaceBendSpecs { get; set; }
        public string? OtherTestResultFilletSpecs { get; set; }
        public string? Remarks { get; set; }
        public int? IsApproved { get; set; }
        public string? CertificateType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
