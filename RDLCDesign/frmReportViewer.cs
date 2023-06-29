using Microsoft.Reporting.WinForms;
using ShakuntEnterprises.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDLCDesign
{
    public partial class frmReportViewer : Form
    {
        ShakuntEnterprisesContext db = new ShakuntEnterprisesContext();
        public frmReportViewer()
        {
            InitializeComponent();

            this.reportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + @"\Reports\TestCertificate.rdlc";
            var certificateData = db.TestCertificateRecords.Where(x => x.Id == 1).ToList();
            
            ReportDataSource testCertificate = new ReportDataSource();
            testCertificate.Name = "TestCertificate";
            testCertificate.Value = "certificateData";
             
            reportViewer1.LocalReport.DataSources.Add(testCertificate);
            this.reportViewer1.Dock = DockStyle.Fill;
            this.reportViewer1.RefreshReport();
        }
    }
}
