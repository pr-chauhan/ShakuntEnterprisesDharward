using System;
using System.Collections.Generic;

namespace ShakuntEnterprises.Models
{
    public partial class UserMaster
    {
        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public string? UserRight { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? Department { get; set; }
        public string? UserRole { get; set; }
    }
}
