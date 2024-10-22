using System;
using System.Collections.Generic;

namespace ShakuntEnterprisesDharward.Models
{
    public partial class NumberSeries
    {
        public int Id { get; set; }
        public string SeriesId { get; set; } = null!;
        public string? SeriesDescription { get; set; }
        public int? SeriesNumber { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
