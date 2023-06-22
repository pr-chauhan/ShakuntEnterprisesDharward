using Microsoft.AspNetCore.Mvc;
using ShakuntEnterprises.Models;
using System.Diagnostics;
using System.Data.Odbc;
using System.Data.Common;
using TallyConnector.Core.Models;
using TallyConnector;
using System.Data;

namespace ShakuntEnterprises.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            return View();
        }
        public IActionResult IndexHome()
        {

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