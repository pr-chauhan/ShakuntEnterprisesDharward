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
        public string? Quanity { get; set; }
        public string? InvoiceNo { get; set; }
        public string? TradeDesignation { get; set; }
        public string? Size { get; set; }
        public string? BatchDate { get; set; }
        public string? BatchNo { get; set; }
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
        public string? ElementMinC { get; set; }
        public string? ElementMinSi { get; set; }
        public string? ElementMinMn { get; set; }
        public string? ElementMinP { get; set; }
        public string? ElementMinS { get; set; }
        public string? ElementMinNi { get; set; }
        public string? ElementMinCr { get; set; }
        public string? ElementMinMo { get; set; }
        public string? ElementMinCu { get; set; }
        public string? ElementMaxC { get; set; }
        public string? ElementMaxSi { get; set; }
        public string? ElementMaxMn { get; set; }
        public string? ElementMaxP { get; set; }
        public string? ElementMaxS { get; set; }
        public string? ElementMaxNi { get; set; }
        public string? ElementMaxCr { get; set; }
        public string? ElementMaxMo { get; set; }
        public string? ElementMaxCu { get; set; }
        public string? TestMinUts { get; set; }
        public string? TestMinYs { get; set; }
        public string? TestMinElongation { get; set; }
        public string? TestMaxUts { get; set; }
        public string? TestMaxYs { get; set; }
        public string? TestMaxElongation { get; set; }
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
        public string? IsShowCelogo { get; set; }
        public string? TallyItemName { get; set; }
        public string? GradeType { get; set; }
    }
}
