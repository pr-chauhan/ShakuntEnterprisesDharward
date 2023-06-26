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
    public class TestCertificateRecordController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShakuntEnterprisesContext _context;
        private CommanClass commanClass;
        public TestCertificateRecordController(ILogger<HomeController> logger, ShakuntEnterprisesContext enterprisesContext)
        {
            _logger = logger;
            _context = enterprisesContext;
            commanClass = new CommanClass(enterprisesContext);

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.Modules = commanClass.getModlueList(HttpContext.Session.GetString("lid"));
            ViewBag.Menus = commanClass.getModlueMenuList(HttpContext.Session.GetString("lid"));
            ViewBag.CDT = DateTime.Now.ToString();

        }
        // GET: TestCertificateRecordController
        public async Task<IActionResult> Index()
        {
            return _context.TestCertificateRecords != null ?
                        View(await _context.TestCertificateRecords.ToListAsync()) :
                        Problem("Entity set 'ShakuntEnterprisesContext.TestCertificateRecords'  is null.");
        }

        // GET: TestCertificateRecordController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestCertificateRecordController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestCertificateRecordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestCertificateRecord testCertificateRecord)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(testCertificateRecord);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(testCertificateRecord);
            }
            return View(testCertificateRecord);
        }

        // GET: TestCertificateRecordController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TestCertificateRecords == null)
            {
                return NotFound();
            }

            var TestCertificateRecords = await _context.TestCertificateRecords.FindAsync(id);
            if (TestCertificateRecords == null)
            {
                return NotFound();
            }
            return View(TestCertificateRecords);
        }

        // POST: TestCertificateRecordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, TestCertificateRecord testCertificateRecord )
        {
            if (id != testCertificateRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testCertificateRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestCertificateRecordExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(testCertificateRecord);
        }
        // GET: TestCertificateRecordController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestCertificateRecordController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private bool TestCertificateRecordExists(int id)
        {
            return (_context.TestCertificateRecords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
