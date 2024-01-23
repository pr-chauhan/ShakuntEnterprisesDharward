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
using TallyConnector.Core.Models.Masters;
using NuGet.Protocol;
using System;
using TallyConnector.Services;
using NToastNotify.Helpers;
using TallyConnector.Core.Converters.XMLConverterHelpers;

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
                //Tally _tallyService = new Tally();
                //Tally _tallyService = new("http://192.168.1.101", 9000);
                //_tallyService.Setup("http://localhost", 9000);
                //_tallyService.Setup("http://192.168.1.101", 9000);
                //_tallyService.Check();
                //var LicesneData = await _tallyService.GetLicenseInfo();
                //string ActiveCompany = _tallyService.GetActiveTallyCompany();
                //string ActiveCompany = _tallyService.GetActiveTallyCompany();
                //var complist = await _tallyService.GetCompaniesList();
                //var complistpath = await _tallyService.GetCompaniesListinPath();
                //_tallyService.ChangeCompany("PRInfosys");
                //_tallyService.GetBasicVoucherData();

                //var MasterStatistics = await _tallyService.GetMasterStatistics();
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

        public async Task<IActionResult> Tally()
        {
            try
            {
                 
                TallyService _tallyService = new("http://localhost", 9000);
                var lVouchers = await _tallyService.GetVouchersAsync<Voucher>(new RequestOptions()
                {
                    FromDate = new(2009, 4, 1),
                    FetchList = Constants.Voucher.InvoiceViewFetchList.All,
                    Filters = new List<Filter>() { Constants.Voucher.Filters.ViewTypeFilters.InvoiceVoucherFilter }

                });
                string pItemName = "Stationary";
                string passItemName = pItemName.ToString();
                string sVoucherNumber;
                int nVourcherNO = 7;
                sVoucherNumber = nVourcherNO.ToString();
                //var Voucheritemlist = lVouchers.Where(x => x.VoucherNumber.Equals(sVoucherNumber)).ToList();
                var Voucheritemlist = lVouchers.Where(x => x.VoucherNumber.Equals(sVoucherNumber)).ToList();
                var talltItemName = Voucheritemlist[0].InventoryAllocations;
                var itemName = Voucheritemlist[0].InventoryAllocations.Where(x => x.StockItemName.Equals(passItemName)).ToList();

                var itemDisplayName = itemName[0].StockItemName;
                var itemQuantity = itemName[0].BilledQuantity;

                //=======================================================================================================
                //_tallyService.Setup("http://localhost", 9000);
                //_tallyService.CheckAsync();
                //var LicesneData = await _tallyService.GetLicenseInfoAsync();
                //var company = await _tallyService.GetActiveCompanyAsync();
                //var com= await  _tallyService.GetCompaniesAsync<Company>();
                //var MasterStatistics = await _tallyService.GetMasterStatisticsAsync();
                //var VoucherStatistics = await _tallyService.GetVoucherStatisticsAsync(
                //new()
                //{
                //    FromDate = new DateTime(2010, 04, 01),
                //    ToDate = new DateTime(2021, 03, 31)
                //});
                ////VoucherStatistics.Where(c => c.Count > 0)
                //var voucherType = await _tallyService.GetVoucherTypeAsync("Sale");
                //var allVoucher = await _tallyService.GetVouchersAsync();
                //var voucherNumber = allVoucher.First(x => x.MasterId.Equals(7)).MasterId;
                //var sVouchers = await _tallyService.GetVoucherAsync(voucherNumber.ToString(),null);

                //var StockItem = await _tallyService.GetStockItemAsync("Stationary", null);
                //var StockItems = await _tallyService.GetStockItemsAsync();
                ////var StockItem = await _tallyService.GetStockItemAsync(sVouchers.MasterId.ToString(), null);


                //var Ledger = await _tallyService.GetLedgersAsync();
                //var tLedger = await _tallyService.GetLedgerAsync("Sale");
                //var StockCategories = await _tallyService.GetStockCategoriesAsync();
                //var StockGroups = await _tallyService.GetStockGroupsAsync();
                //var Groups = await _tallyService.GetGroupsAsync();

                //TallyResult tallyResult = new TallyResult();
                //var res = tallyResult.Response;

                //    new select
                //    InventoryAllocations = x.InventoryAllocations,
                //    BilledQuantity = x.BilledQuantity)
                //    where.(sVoucherNumber)).ToList();
                //);

                //TallyResult _tallyService = new TallyResult();

                //_tallyService = new TallyResult();
                //tall _tallyService = new("http://localhost", 9000);
                //_tallyService.Setup("http://localhost", 9000);
                // _tallyService.Setup("http://192.168.1.101", 9000);
                // _tallyService.Check();
                //var LicesneData = await _tallyService.GetLicenseInfo();
                //string ActiveCompany = _tallyService.GetActiveTallyCompany();
                //string ActiveCompany = _tallyService.GetActiveTallyCompany();
                //var complist =   _tallyService.GetCompaniesList();
                //var complistpath =   _tallyService.GetCompaniesListinPath();
                //_tallyService.ChangeCompany("PRInfosys");
                //_tallyService.GetBasicVoucherData();

                // var MasterStatistics =   _tallyService.FetchAllTallyData();


                //Voucher objLedger = new Voucher();
                //objLedger.VoucherNumber = "7";
                //objLedger. = "Sundry Debtors";
                //objLedger.OPENINGBALANCE = -100;
                //oDll.CREATELEDGER_Async(objLedger);
                //============================================================================================================

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View(ViewBag.Error);
            }
            return View();
        }

                public IActionResult Privacy()
        {
            try
            {
                OdbcConnection DbConnection = new OdbcConnection();
                DbConnection.ConnectionString = @"DSN=TallyODBC64_9000";

                DbConnection.Open();
                OdbcCommand DbCommand = DbConnection.CreateCommand();
                //DbCommand.CommandText = "SELECT $Name FROM StockItem";
                //DbCommand.CommandText = "SELECT $Name FROM Ledger";
                //DbCommand.CommandText = "SELECT * FROM ledger WHERE $Name LIKE '%sale%'";
                DbCommand.CommandText = "SELECT * FROM ODBCTables";
                //DbCommand.CommandText = "SELECT $Name FROM ListofLedgers";
                DbCommand.CommandText = "SELECT * FROM _voucher";
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