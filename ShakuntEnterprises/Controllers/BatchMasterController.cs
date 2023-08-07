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
    public class BatchMasterController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShakuntEnterprisesContext _context;
        private CommanClass commanClass;
        private IConfiguration configuration;
        // GET: BatchMasterController

        public BatchMasterController(ILogger<HomeController> logger, ShakuntEnterprisesContext enterprisesContext, IConfiguration _configuration)
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
            ViewBag.SIZE = commanClass.getAllSizeList();

        }

        public async Task<IActionResult> Index()
        {

            var batchMaster = new BatchMasterModel();
            var lstBatchMaster = await _context.BatchMasters.ToListAsync();
            //foreach(var lst in lstBatchMaster)
            //{
            //    batchMaster.Id = lst.Id;
            //    batchMaster.BarchNo = lst.BarchNo;
            //}
            return View(lstBatchMaster);
        }

        // GET: BatchMasterController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.BatchMasters == null)
            {
                return NotFound();
            }
            var Data = new BatchMasterModel();
            var batchMaster = await _context.BatchMasters.FindAsync(id);
            if (batchMaster != null)
            {
                Data.BarchNo = batchMaster.BarchNo;
                Data.Size = batchMaster.Size;
                Data.ElementResultC = batchMaster.ElementResultC;
                Data.ElementResultSi = batchMaster.ElementResultSi;
                Data.ElementResultMn = batchMaster.ElementResultMn;
                Data.ElementResultP = batchMaster.ElementResultP;
                Data.ElementResultS = batchMaster.ElementResultS;
                Data.ElementResultNi = batchMaster.ElementResultNi;
                Data.ElementResultCr = batchMaster.ElementResultCr;
                Data.ElementResultMo = batchMaster.ElementResultMo;
                Data.ElementResultCu = batchMaster.ElementResultCu;
                Data.TestResultUts = batchMaster.TestResultUts;
                Data.TestResultYs = batchMaster.TestResultYs;
                Data.TestResultElongation = batchMaster.TestResultElongation;
                Data.OtherTestResultRadioSpecs = batchMaster.OtherTestResultRadioSpecs;
                Data.OtherTestResultFaceBendSpecs = batchMaster.OtherTestResultFaceBendSpecs;
                Data.OtherTestResultFilledSpecs = batchMaster.OtherTestResultFilledSpecs;
                Data.TestTemp = batchMaster.TestTemp;
                Data.TestImpectValue = batchMaster.TestImpectValue;
                Data.TestCondition = batchMaster.TestCondition;
                Data.CreatedDate = batchMaster.CreatedDate;
                Data.CreatedBy = batchMaster.CreatedBy;
                Data.ModifiedDate = batchMaster.ModifiedDate;
                Data.ModifiedBy = batchMaster.ModifiedBy;
            }
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // GET: BatchMasterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BatchMasterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BatchMasterModel batchMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Data = new BatchMaster();
                    Data.BarchNo = batchMaster.BarchNo;
                    Data.Size = batchMaster.Size;
                    Data.ElementResultC = batchMaster.ElementResultC;
                    Data.ElementResultSi = batchMaster.ElementResultSi;
                    Data.ElementResultMn = batchMaster.ElementResultMn;
                    Data.ElementResultP = batchMaster.ElementResultP;
                    Data.ElementResultS = batchMaster.ElementResultS;
                    Data.ElementResultNi = batchMaster.ElementResultNi;
                    Data.ElementResultCr = batchMaster.ElementResultCr;
                    Data.ElementResultMo = batchMaster.ElementResultMo;
                    Data.ElementResultCu = batchMaster.ElementResultCu;
                    Data.TestResultUts = batchMaster.TestResultUts;
                    Data.TestResultYs = batchMaster.TestResultYs;
                    Data.TestResultElongation = batchMaster.TestResultElongation;
                    Data.OtherTestResultRadioSpecs = batchMaster.OtherTestResultRadioSpecs;
                    Data.OtherTestResultFaceBendSpecs = batchMaster.OtherTestResultFaceBendSpecs;
                    Data.OtherTestResultFilledSpecs = batchMaster.OtherTestResultFilledSpecs;
                    Data.TestTemp = batchMaster.TestTemp;
                    Data.TestImpectValue = batchMaster.TestImpectValue;
                    Data.TestCondition = batchMaster.TestCondition;
                    Data.CreatedDate = batchMaster.CreatedDate;
                    Data.CreatedBy = batchMaster.CreatedBy;
                    Data.ModifiedDate = batchMaster.ModifiedDate;
                    Data.ModifiedBy = batchMaster.ModifiedBy;
                    _context.Add(Data);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(batchMaster);
            }
            return View(batchMaster);
        }


        // GET: BatchMasterController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BatchMasters == null)
            {
                return NotFound();
            }
            var Data = new BatchMasterModel();
            var batchMaster = await _context.BatchMasters.FindAsync(id);
            if (batchMaster != null)
            {
                Data.BarchNo = batchMaster.BarchNo;
                Data.Size = batchMaster.Size;
                Data.ElementResultC = batchMaster.ElementResultC;
                Data.ElementResultSi = batchMaster.ElementResultSi;
                Data.ElementResultMn = batchMaster.ElementResultMn;
                Data.ElementResultP = batchMaster.ElementResultP;
                Data.ElementResultS = batchMaster.ElementResultS;
                Data.ElementResultNi = batchMaster.ElementResultNi;
                Data.ElementResultCr = batchMaster.ElementResultCr;
                Data.ElementResultMo = batchMaster.ElementResultMo;
                Data.ElementResultCu = batchMaster.ElementResultCu;
                Data.TestResultUts = batchMaster.TestResultUts;
                Data.TestResultYs = batchMaster.TestResultYs;
                Data.TestResultElongation = batchMaster.TestResultElongation;
                Data.OtherTestResultRadioSpecs = batchMaster.OtherTestResultRadioSpecs;
                Data.OtherTestResultFaceBendSpecs = batchMaster.OtherTestResultFaceBendSpecs;
                Data.OtherTestResultFilledSpecs = batchMaster.OtherTestResultFilledSpecs;
                Data.TestTemp = batchMaster.TestTemp;
                Data.TestImpectValue = batchMaster.TestImpectValue;
                Data.TestCondition = batchMaster.TestCondition;
                Data.CreatedDate = batchMaster.CreatedDate;
                Data.CreatedBy = batchMaster.CreatedBy;
                Data.ModifiedDate = batchMaster.ModifiedDate;
                Data.ModifiedBy = batchMaster.ModifiedBy;
            }
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }


        // POST: BatchMasterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, BatchMasterModel batchMaster)
        {
            if (id != batchMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Data = await _context.BatchMasters.FindAsync(id);
                    if (Data != null)
                    {
                        Data.BarchNo = batchMaster.BarchNo;
                        Data.Size = batchMaster.Size;
                        Data.ElementResultC = batchMaster.ElementResultC;
                        Data.ElementResultSi = batchMaster.ElementResultSi;
                        Data.ElementResultMn = batchMaster.ElementResultMn;
                        Data.ElementResultP = batchMaster.ElementResultP;
                        Data.ElementResultS = batchMaster.ElementResultS;
                        Data.ElementResultNi = batchMaster.ElementResultNi;
                        Data.ElementResultCr = batchMaster.ElementResultCr;
                        Data.ElementResultMo = batchMaster.ElementResultMo;
                        Data.ElementResultCu = batchMaster.ElementResultCu;
                        Data.TestResultUts = batchMaster.TestResultUts;
                        Data.TestResultYs = batchMaster.TestResultYs;
                        Data.TestResultElongation = batchMaster.TestResultElongation;
                        Data.OtherTestResultRadioSpecs = batchMaster.OtherTestResultRadioSpecs;
                        Data.OtherTestResultFaceBendSpecs = batchMaster.OtherTestResultFaceBendSpecs;
                        Data.OtherTestResultFilledSpecs = batchMaster.OtherTestResultFilledSpecs;
                        Data.TestTemp = batchMaster.TestTemp;
                        Data.TestImpectValue = batchMaster.TestImpectValue;
                        Data.TestCondition = batchMaster.TestCondition;
                        Data.CreatedDate = batchMaster.CreatedDate;
                        Data.CreatedBy = batchMaster.CreatedBy;
                        Data.ModifiedDate = batchMaster.ModifiedDate;
                        Data.ModifiedBy = batchMaster.ModifiedBy;
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
            return View(batchMaster);
        }


        // GET: BatchMasterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: BatchMasterController/Delete/5
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
            return (_context.BatchMasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
