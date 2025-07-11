﻿using Microsoft.Reporting.WinForms;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RDLCDesign
{
    public partial class frmReportViewer : Form
    {
        ShakuntEnterprisesDharwardContext db = new ShakuntEnterprisesDharwardContext();
        public frmReportViewer()
        {
            InitializeComponent();
            string certificateno = "12";
            //this.reportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + @"\Reports\TestCertificate.rdlc";
            this.reportViewer1.LocalReport.ReportPath =  @"D:\DotNetPlateFormWorkingEnvironment\ShakuntEnterprisesDharward\RDLCDesign\Reports\TestCertificate.rdlc";
            var certificateData = db.TestCertificateRecords.Where(x => x.CertificateNo == certificateno).ToList();
            var certificateResultData = db.TestCertificateResultRecords.Where(x => x.CertificateNo == certificateno).ToList();
            var tradeDesignation = certificateData[0].TradeDesignation.ToString();
            var tradeDesignationMaster = db.TradeDesignationMasters.Where(x => x.TradeDesignation == tradeDesignation).ToList();
            if(certificateData.Count>0 && certificateData[0].isShowElementNiCrMo.ToLower()=="yes")
            {
                this.reportViewer1.LocalReport.ReportPath = @"D:\DotNetPlateFormWorkingEnvironment\ShakuntEnterprisesDharward\RDLCDesign\Reports\TestCertificateCombineColumn.rdlc";
            }
            
            ReportDataSource TestCertificate = new ReportDataSource();
            TestCertificate.Name = "TestCertificate";
            TestCertificate.Value = certificateData;
            ReportDataSource TestCertificateResultRecord = new ReportDataSource();
            TestCertificateResultRecord.Name = "TestCertificateResultRecord";
            TestCertificateResultRecord.Value = certificateResultData;
            ReportDataSource TradeDesignationMasters = new ReportDataSource();
            TradeDesignationMasters.Name = "TradeDesignationMaster";
            TradeDesignationMasters.Value = tradeDesignationMaster;

            reportViewer1.LocalReport.DataSources.Add(TestCertificate);
            reportViewer1.LocalReport.DataSources.Add(TestCertificateResultRecord);
            reportViewer1.LocalReport.DataSources.Add(TradeDesignationMasters);
            this.reportViewer1.Dock = DockStyle.Fill;
            this.reportViewer1.RefreshReport();
        }
    }
}
