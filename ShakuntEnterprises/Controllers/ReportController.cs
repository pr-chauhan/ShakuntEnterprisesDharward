using AspNetCore.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using ShakuntEnterprisesDharward.Models;
using ShakuntEnterprises.Comman;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Microsoft.Reporting.WebForms;
using LocalReport = AspNetCore.Reporting.LocalReport;
using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Data;

namespace ShakuntEnterprises.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private CommanClass commanClass;
        private readonly ShakuntEnterprisesDharwardContext _context;
        private readonly IConfiguration  configuration;

        public ReportController(IWebHostEnvironment webHostEnvironment, ShakuntEnterprisesDharwardContext context, IConfiguration _configuration)
        {
            _context = context;
            this.configuration = _configuration;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            commanClass = new CommanClass(context, configuration);
           
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.Modules = commanClass.getModlueList(HttpContext.Session.GetString("lid"));
            ViewBag.Menus = commanClass.getModlueMenuList(HttpContext.Session.GetString("lid"));
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PrintCertificate(string Id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            try
            {
                int OrderN = int.Parse(Id);
                string mimtype = string.Empty;
                int extension = 1;
                string path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\TestCertificate.rdlc";

                //var certificateRecords = _context.TestCertificateRecords.Where(x => x.Id == OrderN).ToList();
                var certificateRecords = commanClass.getTestCertificateRecordList(Id);
                var certificateResultData = commanClass.getTestCertificateResultRecordList(Id);
                var tradeDesignation = certificateRecords.Rows[0]["TradeDesignation"].ToString();
                var tradeDesignationMaster = commanClass.getTradeDesignationMasterRecord(tradeDesignation);

                if(certificateRecords.Rows.Count>0 && certificateRecords.Rows[0]["isShowElementNiCrMo"].ToString().ToLower() == "yes")
                {
                    path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\TestCertificateCombineColumn.rdlc";
                }

                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("TestCertificate", certificateRecords);
                localReport.AddDataSource("TestCertificateResultRecord", certificateResultData);
                localReport.AddDataSource("TradeDesignationMaster", tradeDesignationMaster);
                
                var result = localReport.Execute(RenderType.Pdf, extension, null, mimtype);
                return File(result.MainStream, "application/pdf", Id.ToString() + "certificateRecords" + ".pdf");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View();
            }


        }
    }
}
