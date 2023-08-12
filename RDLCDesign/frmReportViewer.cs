using Microsoft.Reporting.WinForms;
using ShakuntEnterprises.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string certificateno = "109";
            //this.reportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + @"\Reports\TestCertificate.rdlc";
            this.reportViewer1.LocalReport.ReportPath =  @"D:\DotNetPlateFormWorkingEnvironment\ShakuntEnterprises\RDLCDesign\Reports\TestCertificate.rdlc";
            var certificateData = db.TestCertificateRecords.Where(x => x.CertificateNo == certificateno).ToList();
            var certificateResultData = db.TestCertificateResultRecords.Where(x => x.CertificateNo == certificateno).ToList();
            
            ReportDataSource TestCertificate = new ReportDataSource();
            TestCertificate.Name = "TestCertificate";
            TestCertificate.Value = certificateData;
            ReportDataSource TestCertificateResultRecord = new ReportDataSource();
            TestCertificateResultRecord.Name = "TestCertificateResultRecord";
            TestCertificateResultRecord.Value = certificateResultData;

            reportViewer1.LocalReport.DataSources.Add(TestCertificate);
            reportViewer1.LocalReport.DataSources.Add(TestCertificateResultRecord);
            this.reportViewer1.Dock = DockStyle.Fill;
            this.reportViewer1.RefreshReport();
        }
    }
}
