using Microsoft.AspNetCore.Mvc;
using ShakuntEnterprises.Models;
using System.Diagnostics;
using System.Data.Odbc;
using System.Data.Common;
using TallyConnector.Core.Models;
using TallyConnector;
using System.Data;
using ShakuntEnterprises.Models;
using Microsoft.EntityFrameworkCore;
using ShakuntEnterprises.Comman;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShakuntEnterprises.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShakuntEnterprisesContext _context;
        private CommanClass commanClass;
        private IConfiguration configuration;
        public HomeController(ILogger<HomeController> logger, ShakuntEnterprisesContext enterprisesContext, IConfiguration _configuration)
        {
            _logger = logger;
            _context = enterprisesContext;
            configuration = _configuration;
            commanClass = new CommanClass(enterprisesContext, configuration);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.Modules = commanClass.getModlueList(HttpContext.Session.GetString("lid"));
            ViewBag.Menus = commanClass.getModlueMenuList(HttpContext.Session.GetString("lid"));
            ViewBag.TotalCertificate = commanClass.TotalCertificate();
            ViewBag.TotalPassCertificate = commanClass.TotalPassCertificate();
            ViewBag.TotalFailedCertificate = commanClass.TotalFailedCertificate();
            ViewBag.TotalManualCertificate = commanClass.TotalManualCertificate();
            ViewBag.TotalSystemCertificate = commanClass.TotalSystemCertificate();

        }
        public async Task<string> TallyConnection()
        {
            
            try
            {
                Tally tally = new("http://192.168.1.101", 9000);
                //tally.Setup("http://localhost", 9000);
                tally.Setup("http://192.168.1.101", 9000);
                tally.Check();
                //var LicesneData = await tally.GetLicenseInfo();
                //string ActiveCompany = tally.GetActiveTallyCompany();
                //string ActiveCompany = tally.GetActiveTallyCompany();
                var complist = await tally.GetCompaniesList();
                var complistpath = await tally.GetCompaniesListinPath();
                tally.ChangeCompany("PRInfosys");
                tally.GetBasicVoucherData();

                var MasterStatistics = await tally.GetMasterStatistics();
            }
            catch (Exception ex)
            {

            }
            return "";
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");
            return View();
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("LoginFailed") != null)
            {
                ModelState.AddModelError("LoginFailed", "Invalid login. Please try again..!!");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","Home");

        }
        public IActionResult IndexHome()
        {
            if(HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");
            return View();
        }
        [HttpPost]
        public IActionResult IndexHome(UserMaster userMaster)
        {
            try
            {

                HttpContext.Session.SetString("LoginFailed", "");
                if (!UserMasterExists(userMaster.UserId, userMaster.UserPassword))
                {
                    HttpContext.Session.SetString("LoginFailed", "LoginFailed");
                    return RedirectToAction("Login","Home");
                }
                else
                {
                    HttpContext.Session.SetString("lid", userMaster.UserId);
                    var userData = _context.UserMasters.Where(x => x.UserId.Equals(userMaster.UserId)).FirstOrDefault();
                    if (userData != null)
                    {
                        HttpContext.Session.SetString("ldept", userData.Department);
                        HttpContext.Session.SetString("lrole", userData.UserRole);
                    }
                    ViewBag.Modules = commanClass.getModlueList(userMaster.UserId);
                    ViewBag.Menus = commanClass.getModlueMenuList(userMaster.UserId);
                    string current_date = DateTime.Now.ToShortDateString();
                   
                    return View();
                }
            }
            catch
            {
                HttpContext.Session.SetString("LoginFailed", "LoginFailed");
                return Login();
            }
        }

        private bool UserMasterExists(string id, string password)
        {
            try
            {
                if (commanClass.CheckLicenseDate("SHAKUNTENTERPRISES"))
                    return false;
                var s = _context.UserMasters.ToList();
                var pass = _context.UserMasters.Where(x => x.UserId == id && x.UserPassword == password).ToList();
                if (pass.Count > 0)
                {
                    return _context.UserMasters.Any(e => e.UserId == id);
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public IActionResult Privacy()
        {
            try
            {
                OdbcConnection DbConnection = new OdbcConnection();
                DbConnection.ConnectionString = @"DSN=TallyODBC64_9000";

                DbConnection.Open();
                OdbcCommand DbCommand = DbConnection.CreateCommand();
                DbCommand.CommandText = "SELECT $Name FROM StockItem";
                OdbcDataAdapter dataAdapter = new OdbcDataAdapter(DbCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                string[] stockItems = new string[dataTable.Rows.Count];
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    stockItems[i] = dataTable.Rows[i][0].ToString();
                }

                ViewBag.stockItems = stockItems;
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View(ViewBag.Error);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}