﻿using System;
using System.Collections.Generic;

namespace ShakuntEnterprises.Models
{
    public partial class ModuleList
    {
        public int ModuleId { get; set; }
        public string? ModuleName { get; set; }
        public string? UserId { get; set; }
        public string? UserRight { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? IsActive { get; set; }
    }
}
