﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
 

namespace RDLCDesign
{
    public partial class ShakuntEnterprisesDharwardContext : DbContext
    {
        public ShakuntEnterprisesDharwardContext()
             : base("name=ShakuntEnterprisesEntities")
        {
        }
        public virtual DbSet<TestCertificateRecord> TestCertificateRecords { get; set; } 
        public virtual DbSet<TestCertificateResultRecord> TestCertificateResultRecords { get; set; } 
        public virtual DbSet<TradeDesignationMaster> TradeDesignationMasters { get; set; } 
         
      

        
    }
}
