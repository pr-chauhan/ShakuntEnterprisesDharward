using Microsoft.AspNetCore.Mvc;
using ShakuntEnterprisesDharward.Models;
using System.Diagnostics;
using System.Data.Odbc;
using System.Data.Common;
using TallyConnector.Core.Models;
using TallyConnector;
using System.Data;
using ShakuntEnterprisesDharward.Models;
using ShakuntEnterprises.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShakuntEnterprises.Comman;
using Microsoft.AspNetCore.Mvc.Filters;
using NToastNotify;

namespace ShakuntEnterprises.Controllers
{
    public class BatchMasterController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShakuntEnterprisesDharwardContext _context;
        private CommanClass commanClass;
        private IConfiguration configuration;
        // GET: BatchMasterController
        private readonly IToastNotification _toastNotification;
        public BatchMasterController(ILogger<HomeController> logger, ShakuntEnterprisesDharwardContext enterprisesContext, IConfiguration _configuration, IToastNotification toastNotification)
        {
            _logger = logger;
            _context = enterprisesContext;
            configuration = _configuration;
            _toastNotification = toastNotification;
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
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");
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
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            if (id == null || _context.BatchMasters == null)
            {
                return NotFound();
            }
            var Data = new BatchMasterModel();
            var batchMaster = await _context.BatchMasters.FindAsync(id);
            if (batchMaster != null)
            {
                Data.BatchNo = batchMaster.BatchNo;
                Data.Size = batchMaster.Size;
                Data.ElementResultC = batchMaster.ElementResultC ?? "-----";
                Data.ElementResultSi = batchMaster.ElementResultSi ?? "-----";
                Data.ElementResultMn = batchMaster.ElementResultMn ?? "-----";
                Data.ElementResultP = batchMaster.ElementResultP ?? "-----";
                Data.ElementResultS = batchMaster.ElementResultS ?? "-----";
                Data.ElementResultNi = batchMaster.ElementResultNi ?? "-----";
                Data.ElementResultCr = batchMaster.ElementResultCr ?? "-----";
                Data.ElementResultMo = batchMaster.ElementResultMo ?? "-----";
                Data.ElementResultCu = batchMaster.ElementResultCu ?? "-----";
                Data.ElementResultV = batchMaster.ElementResultV ?? "-----";
                Data.TestResultUts = batchMaster.TestResultUts ?? "-----";
                Data.TestResultYs = batchMaster.TestResultYs ?? "-----";
                Data.TestResultElongation = batchMaster.TestResultElongation ?? "-----";
                Data.OtherTestResultRadioSpecs = batchMaster.OtherTestResultRadioSpecs ?? "-----";
                Data.OtherTestResultFaceBendSpecs = batchMaster.OtherTestResultFaceBendSpecs ?? "-----";
                Data.OtherTestResultFilledSpecs = batchMaster.OtherTestResultFilledSpecs ?? "-----";
                Data.TestResultTemp = batchMaster.TestResultTemp ?? "-----";
                Data.TestResultImpectValue = batchMaster.TestResultImpectValue ?? "-----";
                Data.TestResultCondition = batchMaster.TestResultCondition ?? "-----";
                Data.CreatedDate = batchMaster.CreatedDate;
                Data.CreatedBy = batchMaster.CreatedBy;
                Data.ModifiedDate = batchMaster.ModifiedDate;
                Data.ModifiedBy = batchMaster.ModifiedBy;
                Data.TestResultNiCrMo = batchMaster.TestResultNiCrMo ?? "-----"; 
            }
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // GET: BatchMasterController/Create
        public ActionResult Create()
        {if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");
            return View();
        }

        // POST: BatchMasterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BatchMasterModel batchMaster)
        {
            try
            {
                if (HttpContext.Session.GetString("lid") == null)
                    return RedirectToAction("Login","Home");
                if (ModelState.IsValid)
                {
                    var Data = new BatchMaster();
                    Data.BatchNo = batchMaster.BatchNo;
                    Data.Size = batchMaster.Size;
                    Data.ElementResultC = batchMaster.ElementResultC ?? "-----";
                    Data.ElementResultSi = batchMaster.ElementResultSi ?? "-----";
                    Data.ElementResultMn = batchMaster.ElementResultMn ?? "-----";
                    Data.ElementResultP = batchMaster.ElementResultP ?? "-----";
                    Data.ElementResultS = batchMaster.ElementResultS ?? "-----";
                    Data.ElementResultNi = batchMaster.ElementResultNi ?? "-----";
                    Data.ElementResultCr = batchMaster.ElementResultCr ?? "-----";
                    Data.ElementResultMo = batchMaster.ElementResultMo ?? "-----";
                    Data.ElementResultCu = batchMaster.ElementResultCu ?? "-----";
                    Data.ElementResultV = batchMaster.ElementResultV ?? "-----";
                    Data.TestResultUts = batchMaster.TestResultUts ?? "-----";
                    Data.TestResultYs = batchMaster.TestResultYs ?? "-----";
                    Data.TestResultElongation = batchMaster.TestResultElongation ?? "-----";
                    Data.OtherTestResultRadioSpecs = batchMaster.OtherTestResultRadioSpecs ?? "-----";
                    Data.OtherTestResultFaceBendSpecs = batchMaster.OtherTestResultFaceBendSpecs ?? "-----";
                    Data.OtherTestResultFilledSpecs = batchMaster.OtherTestResultFilledSpecs ?? "-----";
                    Data.TestResultTemp = batchMaster.TestResultTemp ?? "-----";
                    Data.TestResultImpectValue = batchMaster.TestResultImpectValue ?? "-----";
                    Data.TestResultCondition = batchMaster.TestResultCondition ?? "-----";
                    Data.CreatedDate = batchMaster.CreatedDate;
                    Data.CreatedBy = batchMaster.CreatedBy;
                    Data.ModifiedDate = batchMaster.ModifiedDate;
                    Data.ModifiedBy = batchMaster.ModifiedBy;
                    Data.TestResultNiCrMo = batchMaster.TestResultNiCrMo ?? "-----";
                    _context.Add(Data);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage(batchMaster.BatchNo + " Created successfully!");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                _toastNotification.AddSuccessToastMessage(batchMaster.BatchNo + " Failed to created!");
                return View(batchMaster);
            }
            return View(batchMaster);
        }


        // GET: BatchMasterController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");
            if (id == null || _context.BatchMasters == null)
            {
                return NotFound();
            }
            var Data = new BatchMasterModel();
            var batchMaster = await _context.BatchMasters.FindAsync(id);
            if (batchMaster != null)
            {
                Data.BatchNo = batchMaster.BatchNo;
                Data.Size = batchMaster.Size;
                Data.ElementResultC = batchMaster.ElementResultC ?? "-----";
                Data.ElementResultSi = batchMaster.ElementResultSi ?? "-----";
                Data.ElementResultMn = batchMaster.ElementResultMn ?? "-----";
                Data.ElementResultP = batchMaster.ElementResultP ?? "-----";
                Data.ElementResultS = batchMaster.ElementResultS ?? "-----";
                Data.ElementResultNi = batchMaster.ElementResultNi ?? "-----";
                Data.ElementResultCr = batchMaster.ElementResultCr ?? "-----";
                Data.ElementResultMo = batchMaster.ElementResultMo ?? "-----";
                Data.ElementResultCu = batchMaster.ElementResultCu ?? "-----";
                Data.ElementResultV = batchMaster.ElementResultV ?? "-----";
                Data.TestResultUts = batchMaster.TestResultUts ?? "-----";
                Data.TestResultYs = batchMaster.TestResultYs ?? "-----";
                Data.TestResultElongation = batchMaster.TestResultElongation ?? "-----";
                Data.OtherTestResultRadioSpecs = batchMaster.OtherTestResultRadioSpecs ?? "-----";
                Data.OtherTestResultFaceBendSpecs = batchMaster.OtherTestResultFaceBendSpecs ?? "-----";
                Data.OtherTestResultFilledSpecs = batchMaster.OtherTestResultFilledSpecs ?? "-----";
                Data.TestResultTemp = batchMaster.TestResultTemp ?? "-----";
                Data.TestResultImpectValue = batchMaster.TestResultImpectValue ?? "-----";
                Data.TestResultCondition = batchMaster.TestResultCondition ?? "-----";
                Data.CreatedDate = batchMaster.CreatedDate;
                Data.CreatedBy = batchMaster.CreatedBy;
                Data.ModifiedDate = batchMaster.ModifiedDate;
                Data.ModifiedBy = batchMaster.ModifiedBy;
                Data.TestResultNiCrMo = batchMaster.TestResultNiCrMo ?? "-----";
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
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");
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
                        Data.BatchNo = batchMaster.BatchNo;
                        Data.Size = batchMaster.Size;
                        Data.ElementResultC = batchMaster.ElementResultC ?? "-----";
                        Data.ElementResultSi = batchMaster.ElementResultSi ?? "-----";
                        Data.ElementResultMn = batchMaster.ElementResultMn ?? "-----";
                        Data.ElementResultP = batchMaster.ElementResultP ?? "-----";
                        Data.ElementResultS = batchMaster.ElementResultS ?? "-----";
                        Data.ElementResultNi = batchMaster.ElementResultNi ?? "-----";
                        Data.ElementResultCr = batchMaster.ElementResultCr ?? "-----";
                        Data.ElementResultMo = batchMaster.ElementResultMo ?? "-----";
                        Data.ElementResultCu = batchMaster.ElementResultCu ?? "-----";
                        Data.ElementResultV = batchMaster.ElementResultV ?? "-----";
                        Data.TestResultUts = batchMaster.TestResultUts ?? "-----";
                        Data.TestResultYs = batchMaster.TestResultYs ?? "-----";
                        Data.TestResultElongation = batchMaster.TestResultElongation ?? "-----";
                        Data.OtherTestResultRadioSpecs = batchMaster.OtherTestResultRadioSpecs ?? "-----";
                        Data.OtherTestResultFaceBendSpecs = batchMaster.OtherTestResultFaceBendSpecs ?? "-----";
                        Data.OtherTestResultFilledSpecs = batchMaster.OtherTestResultFilledSpecs ?? "-----";
                        Data.TestResultTemp = batchMaster.TestResultTemp ?? "-----";
                        Data.TestResultImpectValue = batchMaster.TestResultImpectValue ?? "-----";
                        Data.TestResultCondition = batchMaster.TestResultCondition ?? "-----";
                        Data.CreatedDate = batchMaster.CreatedDate;
                        Data.CreatedBy = batchMaster.CreatedBy;
                        Data.ModifiedDate = batchMaster.ModifiedDate;
                        Data.ModifiedBy = batchMaster.ModifiedBy;
                        Data.TestResultNiCrMo = batchMaster.TestResultNiCrMo ?? "-----";
                    }
                    _context.Update(Data);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage(batchMaster.BatchNo + " Updated successfully!");
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
        {if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");
            return View();
        }


        // POST: BatchMasterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");
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
