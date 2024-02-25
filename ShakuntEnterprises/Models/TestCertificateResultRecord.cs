using System;
using System.Collections.Generic;

namespace ShakuntEnterprises.Models
{
    public partial class TestCertificateResultRecord
    {
        public int Id { get; set; }
        public string? BatchDate { get; set; }
        public string? BatchNo { get; set; }
        public string? Size { get; set; }
        public string? CertificateNo { get; set; }
        public string? ElementResultC { get; set; }
        public string? ElementResultSi { get; set; }
        public string? ElementResultMn { get; set; }
        public string? ElementResultP { get; set; }
        public string? ElementResultS { get; set; }
        public string? ElementResultNi { get; set; }
        public string? ElementResultCr { get; set; }
        public string? ElementResultMo { get; set; }
        public string? ElementResultCu { get; set; }
        public string? TestResultUts { get; set; }
        public string? TestResultYs { get; set; }
        public string? TestResultElongation { get; set; }
        public string? TestTemp { get; set; }
        public string? TestImpectValue { get; set; }
        public string? TestCondition { get; set; }
        public string? OtherTestResultRadioSpecs { get; set; }
        public string? OtherTestResultFaceBendSpecs { get; set; }
        public string? OtherTestResultFilledSpecs { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CombineMfgdate { get; set; }
    }
}
