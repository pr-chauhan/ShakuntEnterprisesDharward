//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RDLCDesign
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestCertificateResultRecord
    {
        public int Id { get; set; }
        public string BatchNo { get; set; }
        public string Size { get; set; }
        public string CertificateNo { get; set; }
        public Nullable<decimal> Element_Result_C { get; set; }
        public Nullable<decimal> Element_Result_SI { get; set; }
        public Nullable<decimal> Element_Result_MN { get; set; }
        public Nullable<decimal> Element_Result_P { get; set; }
        public Nullable<decimal> Element_Result_S { get; set; }
        public Nullable<decimal> Element_Result_NI { get; set; }
        public Nullable<decimal> Element_Result_CR { get; set; }
        public Nullable<decimal> Element_Result_MO { get; set; }
        public Nullable<decimal> Element_Result_CU { get; set; }
        public Nullable<decimal> Test_Result_UTS { get; set; }
        public Nullable<decimal> Test_Result_YS { get; set; }
        public Nullable<decimal> Test_Result_Elongation { get; set; }
        public string Test_Temp { get; set; }
        public string Test_ImpectValue { get; set; }
        public string Test_Condition { get; set; }
        public string OtherTestResult_Radio_Specs { get; set; }
        public string OtherTestResult_FaceBend_Specs { get; set; }
        public string OtherTestResult_Filled_Specs { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public string Modified_By { get; set; }
    }
}