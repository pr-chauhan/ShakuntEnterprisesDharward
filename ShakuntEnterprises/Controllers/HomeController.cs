using Microsoft.AspNetCore.Mvc;
using ShakuntEnterprises.Models;
using System.Diagnostics;
using System.Data.Odbc;
using System.Data.Common;

namespace ShakuntEnterprises.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            OdbcConnection DbConnection = new OdbcConnection("DSN=TallyODBC64_9000");
            //OdbcConnection DbConnection = new OdbcConnection();
            //DbConnection.ConnectionString = @"D:\TallyODBC64_9000.dsn";
            DbConnection.Open();
            OdbcCommand DbCommand = DbConnection.CreateCommand();
            DbCommand.CommandText = "SELECT * FROM StockItem";
            OdbcDataReader DbReader = DbCommand.ExecuteReader();
            int fCount = DbReader.FieldCount;
            Console.Write(":");
            for (int i = 0; i < fCount; i++)
            {
                String fName = DbReader.GetName(i);
                Console.Write(fName + ":");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}