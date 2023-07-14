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
    public class TradeDesignationMasterController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShakuntEnterprisesContext _context;
        private CommanClass commanClass;
        private IConfiguration configuration;
        // GET: TradeDesignationMasterController

        public TradeDesignationMasterController(ILogger<HomeController> logger, ShakuntEnterprisesContext enterprisesContext, IConfiguration _configuration)
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

            var tradeDesignationMasterModel = new TradeDesignationMasterModel();
            var lstTradeDesignationMasters = await _context.TradeDesignationMasters.ToListAsync();
            //foreach (var lst in lstTradeDesignationMasters)
            //{
            //    tradeDesignationMasterModel.Id = lst.Id;
            //    tradeDesignationMasterModel.TradeDesignation = lst.TradeDesignation;
            //}
            return View(lstTradeDesignationMasters);

        }

        // GET: TradeDesignationMasterController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.TradeDesignationMasters == null)
            {
                return NotFound();
            }
            var Data = new TradeDesignationMasterModel();
            var tradeDesignationMaster = await _context.TradeDesignationMasters.FindAsync(id);
            if (tradeDesignationMaster != null)
            {
                Data.TradeDesignation = tradeDesignationMaster.TradeDesignation;
                Data.Size = tradeDesignationMaster.Size;
                Data.WeldingProcess = tradeDesignationMaster.WeldingProcess;
                Data.ShieldingGas = tradeDesignationMaster.ShieldingGas;
                Data.PreHeatInerpassTemp = tradeDesignationMaster.PreHeatInerpassTemp;
                Data.Type = tradeDesignationMaster.Type;
                Data.FlowRate = tradeDesignationMaster.FlowRate;
                Data.CurrentPolarity = tradeDesignationMaster.CurrentPolarity;
                Data.BaseMetal = tradeDesignationMaster.BaseMetal;
                Data.ElementMinC = tradeDesignationMaster.ElementMinC;
                Data.ElementMinSi = tradeDesignationMaster.ElementMinSi;
                Data.ElementMinMn = tradeDesignationMaster.ElementMinMn;
                Data.ElementMinP = tradeDesignationMaster.ElementMinP;
                Data.ElementMinS = tradeDesignationMaster.ElementMinS;
                Data.ElementMinNi = tradeDesignationMaster.ElementMinNi;
                Data.ElementMinCr = tradeDesignationMaster.ElementMinCr;
                Data.ElementMinMo = tradeDesignationMaster.ElementMinMo;
                Data.ElementMinCu = tradeDesignationMaster.ElementMinCu;
                Data.ElementMaxC = tradeDesignationMaster.ElementMaxC;
                Data.ElementMaxSi = tradeDesignationMaster.ElementMaxSi;
                Data.ElementMaxMn = tradeDesignationMaster.ElementMaxMn;
                Data.ElementMaxP = tradeDesignationMaster.ElementMaxP;
                Data.ElementMaxS = tradeDesignationMaster.ElementMaxS;
                Data.ElementMaxNi = tradeDesignationMaster.ElementMaxNi;
                Data.ElementMaxCr = tradeDesignationMaster.ElementMaxCr;
                Data.ElementMaxMo = tradeDesignationMaster.ElementMaxMo;
                Data.ElementMaxCu = tradeDesignationMaster.ElementMaxCu;
                Data.TestMinUts = tradeDesignationMaster.TestMinUts;
                Data.TestMinYs = tradeDesignationMaster.TestMinYs;
                Data.TestMinElongation = tradeDesignationMaster.TestMinElongation;
                Data.TestMaxUts = tradeDesignationMaster.TestMaxUts;
                Data.TestMaxYs = tradeDesignationMaster.TestMaxYs;
                Data.TestMaxElongation = tradeDesignationMaster.TestMaxElongation;
                Data.TestTemp = tradeDesignationMaster.TestTemp;
                Data.TestImpectValue = tradeDesignationMaster.TestImpectValue;
                Data.TestCondition = tradeDesignationMaster.TestCondition;
                Data.CreatedDate = tradeDesignationMaster.CreatedDate;
                Data.CreatedBy = tradeDesignationMaster.CreatedBy;
                Data.ModifiedDate = tradeDesignationMaster.ModifiedDate;
                Data.ModifiedBy = tradeDesignationMaster.ModifiedBy;
            }
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // GET: TradeDesignationMasterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TradeDesignationMasterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TradeDesignationMasterModel tradeDesignationMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Data = new TradeDesignationMaster();
                    Data.TradeDesignation = tradeDesignationMaster.TradeDesignation;
                    Data.Size = tradeDesignationMaster.Size;
                    Data.WeldingProcess = tradeDesignationMaster.WeldingProcess;
                    Data.ShieldingGas = tradeDesignationMaster.ShieldingGas;
                    Data.PreHeatInerpassTemp = tradeDesignationMaster.PreHeatInerpassTemp;
                    Data.Type = tradeDesignationMaster.Type;
                    Data.FlowRate = tradeDesignationMaster.FlowRate;
                    Data.CurrentPolarity = tradeDesignationMaster.CurrentPolarity;
                    Data.BaseMetal = tradeDesignationMaster.BaseMetal;
                    Data.ElementMinC = tradeDesignationMaster.ElementMinC;
                    Data.ElementMinSi = tradeDesignationMaster.ElementMinSi;
                    Data.ElementMinMn = tradeDesignationMaster.ElementMinMn;
                    Data.ElementMinP = tradeDesignationMaster.ElementMinP;
                    Data.ElementMinS = tradeDesignationMaster.ElementMinS;
                    Data.ElementMinNi = tradeDesignationMaster.ElementMinNi;
                    Data.ElementMinCr = tradeDesignationMaster.ElementMinCr;
                    Data.ElementMinMo = tradeDesignationMaster.ElementMinMo;
                    Data.ElementMinCu = tradeDesignationMaster.ElementMinCu;
                    Data.ElementMaxC = tradeDesignationMaster.ElementMaxC;
                    Data.ElementMaxSi = tradeDesignationMaster.ElementMaxSi;
                    Data.ElementMaxMn = tradeDesignationMaster.ElementMaxMn;
                    Data.ElementMaxP = tradeDesignationMaster.ElementMaxP;
                    Data.ElementMaxS = tradeDesignationMaster.ElementMaxS;
                    Data.ElementMaxNi = tradeDesignationMaster.ElementMaxNi;
                    Data.ElementMaxCr = tradeDesignationMaster.ElementMaxCr;
                    Data.ElementMaxMo = tradeDesignationMaster.ElementMaxMo;
                    Data.ElementMaxCu = tradeDesignationMaster.ElementMaxCu;
                    Data.TestMinUts = tradeDesignationMaster.TestMinUts;
                    Data.TestMinYs = tradeDesignationMaster.TestMinYs;
                    Data.TestMinElongation = tradeDesignationMaster.TestMinElongation;
                    Data.TestMaxUts = tradeDesignationMaster.TestMaxUts;
                    Data.TestMaxYs = tradeDesignationMaster.TestMaxYs;
                    Data.TestMaxElongation = tradeDesignationMaster.TestMaxElongation;
                    Data.TestTemp = tradeDesignationMaster.TestTemp;
                    Data.TestImpectValue = tradeDesignationMaster.TestImpectValue;
                    Data.TestCondition = tradeDesignationMaster.TestCondition;
                    Data.CreatedDate = tradeDesignationMaster.CreatedDate;
                    Data.CreatedBy = tradeDesignationMaster.CreatedBy;
                    Data.ModifiedDate = tradeDesignationMaster.ModifiedDate;
                    Data.ModifiedBy = tradeDesignationMaster.ModifiedBy;
                    _context.Add(Data);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(tradeDesignationMaster);
            }
            return View(tradeDesignationMaster);
        }


        // GET: TradeDesignationMasterController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TradeDesignationMasters == null)
            {
                return NotFound();
            }
            var Data = new TradeDesignationMasterModel();
            var tradeDesignationMaster = await _context.TradeDesignationMasters.FindAsync(id);
            if (tradeDesignationMaster != null)
            {
                Data.TradeDesignation = tradeDesignationMaster.TradeDesignation;
                Data.Size = tradeDesignationMaster.Size;
                Data.WeldingProcess = tradeDesignationMaster.WeldingProcess;
                Data.ShieldingGas = tradeDesignationMaster.ShieldingGas;
                Data.PreHeatInerpassTemp = tradeDesignationMaster.PreHeatInerpassTemp;
                Data.Type = tradeDesignationMaster.Type;
                Data.FlowRate = tradeDesignationMaster.FlowRate;
                Data.CurrentPolarity = tradeDesignationMaster.CurrentPolarity;
                Data.BaseMetal = tradeDesignationMaster.BaseMetal;
                Data.ElementMinC = tradeDesignationMaster.ElementMinC;
                Data.ElementMinSi = tradeDesignationMaster.ElementMinSi;
                Data.ElementMinMn = tradeDesignationMaster.ElementMinMn;
                Data.ElementMinP = tradeDesignationMaster.ElementMinP;
                Data.ElementMinS = tradeDesignationMaster.ElementMinS;
                Data.ElementMinNi = tradeDesignationMaster.ElementMinNi;
                Data.ElementMinCr = tradeDesignationMaster.ElementMinCr;
                Data.ElementMinMo = tradeDesignationMaster.ElementMinMo;
                Data.ElementMinCu = tradeDesignationMaster.ElementMinCu;
                Data.ElementMaxC = tradeDesignationMaster.ElementMaxC;
                Data.ElementMaxSi = tradeDesignationMaster.ElementMaxSi;
                Data.ElementMaxMn = tradeDesignationMaster.ElementMaxMn;
                Data.ElementMaxP = tradeDesignationMaster.ElementMaxP;
                Data.ElementMaxS = tradeDesignationMaster.ElementMaxS;
                Data.ElementMaxNi = tradeDesignationMaster.ElementMaxNi;
                Data.ElementMaxCr = tradeDesignationMaster.ElementMaxCr;
                Data.ElementMaxMo = tradeDesignationMaster.ElementMaxMo;
                Data.ElementMaxCu = tradeDesignationMaster.ElementMaxCu;
                Data.TestMinUts = tradeDesignationMaster.TestMinUts;
                Data.TestMinYs = tradeDesignationMaster.TestMinYs;
                Data.TestMinElongation = tradeDesignationMaster.TestMinElongation;
                Data.TestMaxUts = tradeDesignationMaster.TestMaxUts;
                Data.TestMaxYs = tradeDesignationMaster.TestMaxYs;
                Data.TestMaxElongation = tradeDesignationMaster.TestMaxElongation;
                Data.TestTemp = tradeDesignationMaster.TestTemp;
                Data.TestImpectValue = tradeDesignationMaster.TestImpectValue;
                Data.TestCondition = tradeDesignationMaster.TestCondition;
                Data.CreatedDate = tradeDesignationMaster.CreatedDate;
                Data.CreatedBy = tradeDesignationMaster.CreatedBy;
                Data.ModifiedDate = tradeDesignationMaster.ModifiedDate;
                Data.ModifiedBy = tradeDesignationMaster.ModifiedBy;
            }
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }


        // POST: TradeDesignationMasterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, TradeDesignationMasterModel tradeDesignationMaster)
        {
            if (id != tradeDesignationMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Data = await _context.TradeDesignationMasters.FindAsync(id);
                    if (Data != null)
                    {
                        Data.TradeDesignation = tradeDesignationMaster.TradeDesignation;
                        Data.Size = tradeDesignationMaster.Size;
                        Data.WeldingProcess = tradeDesignationMaster.WeldingProcess;
                        Data.ShieldingGas = tradeDesignationMaster.ShieldingGas;
                        Data.PreHeatInerpassTemp = tradeDesignationMaster.PreHeatInerpassTemp;
                        Data.Type = tradeDesignationMaster.Type;
                        Data.FlowRate = tradeDesignationMaster.FlowRate;
                        Data.CurrentPolarity = tradeDesignationMaster.CurrentPolarity;
                        Data.BaseMetal = tradeDesignationMaster.BaseMetal;
                        Data.ElementMinC = tradeDesignationMaster.ElementMinC;
                        Data.ElementMinSi = tradeDesignationMaster.ElementMinSi;
                        Data.ElementMinMn = tradeDesignationMaster.ElementMinMn;
                        Data.ElementMinP = tradeDesignationMaster.ElementMinP;
                        Data.ElementMinS = tradeDesignationMaster.ElementMinS;
                        Data.ElementMinNi = tradeDesignationMaster.ElementMinNi;
                        Data.ElementMinCr = tradeDesignationMaster.ElementMinCr;
                        Data.ElementMinMo = tradeDesignationMaster.ElementMinMo;
                        Data.ElementMinCu = tradeDesignationMaster.ElementMinCu;
                        Data.ElementMaxC = tradeDesignationMaster.ElementMaxC;
                        Data.ElementMaxSi = tradeDesignationMaster.ElementMaxSi;
                        Data.ElementMaxMn = tradeDesignationMaster.ElementMaxMn;
                        Data.ElementMaxP = tradeDesignationMaster.ElementMaxP;
                        Data.ElementMaxS = tradeDesignationMaster.ElementMaxS;
                        Data.ElementMaxNi = tradeDesignationMaster.ElementMaxNi;
                        Data.ElementMaxCr = tradeDesignationMaster.ElementMaxCr;
                        Data.ElementMaxMo = tradeDesignationMaster.ElementMaxMo;
                        Data.ElementMaxCu = tradeDesignationMaster.ElementMaxCu;
                        Data.TestMinUts = tradeDesignationMaster.TestMinUts;
                        Data.TestMinYs = tradeDesignationMaster.TestMinYs;
                        Data.TestMinElongation = tradeDesignationMaster.TestMinElongation;
                        Data.TestMaxUts = tradeDesignationMaster.TestMaxUts;
                        Data.TestMaxYs = tradeDesignationMaster.TestMaxYs;
                        Data.TestMaxElongation = tradeDesignationMaster.TestMaxElongation;
                        Data.TestTemp = tradeDesignationMaster.TestTemp;
                        Data.TestImpectValue = tradeDesignationMaster.TestImpectValue;
                        Data.TestCondition = tradeDesignationMaster.TestCondition;
                        Data.CreatedDate = tradeDesignationMaster.CreatedDate;
                        Data.CreatedBy = tradeDesignationMaster.CreatedBy;
                        Data.ModifiedDate = tradeDesignationMaster.ModifiedDate;
                        Data.ModifiedBy = tradeDesignationMaster.ModifiedBy;
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
            return View(tradeDesignationMaster);
        }


        // GET: TradeDesignationMasterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: TradeDesignationMasterController/Delete/5
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
            return (_context.TradeDesignationMasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
