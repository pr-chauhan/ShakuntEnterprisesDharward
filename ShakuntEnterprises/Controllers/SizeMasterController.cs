using Microsoft.AspNetCore.Mvc;
using ShakuntEnterprises.Models;
using System.Diagnostics;
using System.Data.Odbc;
using System.Data.Common;
using TallyConnector.Core.Models;
using TallyConnector;
using System.Data;
using ShakuntEnterprises.Models;
using ShakuntEnterprises.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShakuntEnterprises.Comman;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShakuntEnterprises.Controllers
{
    public class SizeMasterController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShakuntEnterprisesContext _context;
        private CommanClass commanClass;
        private IConfiguration configuration;
        // GET: SizeMasterController

        public SizeMasterController(ILogger<HomeController> logger, ShakuntEnterprisesContext enterprisesContext, IConfiguration _configuration)
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
            ViewBag.CDT = DateTime.Now.ToString();

        }
        public async Task<IActionResult> Index()
        {
            var sizeMaster = new SizeMasterModel();
            var lstSizeMaster = await _context.SizeMasters.ToListAsync();
            //foreach (var lst in lstSizeMaster)
            //{
            //    sizeMaster.Id = lst.Id;
            //    sizeMaster.Size = lst.Size;
            //}
            return View(lstSizeMaster);
        }

        // GET: SizeMasterController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.SizeMasters == null)
            {
                return NotFound();
            }
            var Data = new SizeMasterModel();
            var sizeMaster = await _context.SizeMasters.FindAsync(id);
            if (sizeMaster != null)
            {
                Data.Size = sizeMaster.Size;
                Data.Apms = sizeMaster.Apms;
                Data.Volts = sizeMaster.Volts;
                Data.TravelSpeed = sizeMaster.TravelSpeed;
                Data.CreatedDate = sizeMaster.CreatedDate;
                Data.CreatedBy = sizeMaster.CreatedBy;
                Data.ModifiedDate = sizeMaster.ModifiedDate;
                Data.ModifiedBy = sizeMaster.ModifiedBy;
            }
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // GET: SizeMasterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SizeMasterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SizeMasterModel sizeMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Data = new SizeMaster();
                    Data.Size = sizeMaster.Size;
                    Data.Apms = sizeMaster.Apms;
                    Data.Volts = sizeMaster.Volts;
                    Data.TravelSpeed = sizeMaster.TravelSpeed;
                    Data.CreatedDate = sizeMaster.CreatedDate;
                    Data.CreatedBy = sizeMaster.CreatedBy;
                    Data.ModifiedDate = sizeMaster.ModifiedDate;
                    Data.ModifiedBy = sizeMaster.ModifiedBy;
                    _context.Add(Data);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(sizeMaster);
            }
            return View(sizeMaster);
        }


        // GET: SizeMasterController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SizeMasters == null)
            {
                return NotFound();
            }
            var Data = new SizeMasterModel();
            var sizeMaster = await _context.SizeMasters.FindAsync(id);
            if (sizeMaster != null)
            {
                Data.Size = sizeMaster.Size;
                Data.Apms = sizeMaster.Apms;
                Data.Volts = sizeMaster.Volts;
                Data.TravelSpeed = sizeMaster.TravelSpeed;
                Data.CreatedDate = sizeMaster.CreatedDate;
                Data.CreatedBy = sizeMaster.CreatedBy;
                Data.ModifiedDate = sizeMaster.ModifiedDate;
                Data.ModifiedBy = sizeMaster.ModifiedBy;
            }
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }


        // POST: SizeMasterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, SizeMasterModel sizeMaster)
        {
            if (id != sizeMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Data = await _context.SizeMasters.FindAsync(id);
                    if (Data != null)
                    {
                        Data.Size = sizeMaster.Size;
                        Data.Apms = sizeMaster.Apms;
                        Data.Volts = sizeMaster.Volts;
                        Data.TravelSpeed = sizeMaster.TravelSpeed;
                        Data.CreatedDate = sizeMaster.CreatedDate;
                        Data.CreatedBy = sizeMaster.CreatedBy;
                        Data.ModifiedDate = sizeMaster.ModifiedDate;
                        Data.ModifiedBy = sizeMaster.ModifiedBy;
                    }
                    _context.Update(Data);
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
            return View(sizeMaster);
        }


        // GET: SizeMasterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: SizeMasterController/Delete/5
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
            return (_context.SizeMasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
