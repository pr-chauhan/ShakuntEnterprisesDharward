﻿using System;
using System.Collections.Generic;

namespace ShakuntEnterprises.Models
{
    public partial class SizeMaster
    {
        public int Id { get; set; }
        public string? Size { get; set; }
        public string? Apms { get; set; }
        public string? Volts { get; set; }
        public string? TravelSpeed { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}