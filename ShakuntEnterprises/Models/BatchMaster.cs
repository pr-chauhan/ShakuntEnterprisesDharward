﻿using System;
using System.Collections.Generic;

namespace ShakuntEnterprises.Models
{
    public partial class BatchMaster
    {
        public int Id { get; set; }
        public string? BarchNo { get; set; }
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
        public decimal? TestMinUts { get; set; }
        public decimal? TestMinYs { get; set; }
        public decimal? TestMinElongation { get; set; }
        public decimal? TestMaxUts { get; set; }
        public decimal? TestMaxYs { get; set; }
        public decimal? TestMaxElongation { get; set; }
        public string? TestTemp { get; set; }
        public string? TestImpectValue { get; set; }
        public string? TestCondition { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}