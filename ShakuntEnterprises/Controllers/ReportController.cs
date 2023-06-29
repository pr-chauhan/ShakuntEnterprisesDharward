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
using ShakuntEnterprises.Models;
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
        private readonly ShakuntEnterprisesContext _context;
        private readonly IConfiguration  configuration;

        public ReportController(IWebHostEnvironment webHostEnvironment, ShakuntEnterprisesContext context, IConfiguration _configuration)
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
            try
            {
                int OrderN = int.Parse(Id);
                string mimtype = string.Empty;
                int extension = 1;
                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\TestCertificate.rdlc";
                
                var certificateRecords = _context.TestCertificateRecords.Where(x => x.Id == OrderN).ToList();
                
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("TestCertificate", certificateRecords);
                
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
