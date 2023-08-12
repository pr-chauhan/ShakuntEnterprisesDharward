using System;
using System.Collections.Generic;
using System.Data.Entity;
 

namespace RDLCDesign
{
    public partial class ShakuntEnterprisesContext : DbContext
    {
        public ShakuntEnterprisesContext()
             : base("name=ShakuntEnterprisesEntities")
        {
        }
        public virtual DbSet<TestCertificateRecord> TestCertificateRecords { get; set; } 
        public virtual DbSet<TestCertificateResultRecord> TestCertificateResultRecords { get; set; } 
      

        
    }
}
