using System;
using System.Collections.Generic;

namespace ShakuntEnterprises.Models
{
    public partial class TradeDesignationGradeType
    {
        public int Id { get; set; }
        public string? GradeType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
