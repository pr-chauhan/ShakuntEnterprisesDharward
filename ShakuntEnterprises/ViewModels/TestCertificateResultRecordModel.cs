using System;
using System.Collections.Generic;

namespace ShakuntEnterprises.Models
{
    public class TestCertificateResultRecordModel
    {
        public int Id { get; set; }
        public string? BatchNo { get; set; }
        public string? Size { get; set; }
        public string? CertificateNo { get; set; }
        public decimal? ElementResultC { get; set; }
        public decimal? ElementResultSi { get; set; }
        public decimal? ElementResultMn { get; set; }
        public decimal? ElementResultP { get; set; }
        public decimal? ElementResultS { get; set; }
        public decimal? ElementResultNi { get; set; }
        public decimal? ElementResultCr { get; set; }
        public decimal? ElementResultMo { get; set; }
        public decimal? ElementResultCu { get; set; }
        public decimal? TestResultUts { get; set; }
        public decimal? TestResultYs { get; set; }
        public decimal? TestResultElongation { get; set; }
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
    }
}
