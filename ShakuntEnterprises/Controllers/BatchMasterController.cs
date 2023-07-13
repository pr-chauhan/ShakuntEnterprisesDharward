﻿using Microsoft.AspNetCore.Mvc;
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
                Data.ElementMinC = batchMaster.ElementMinC;
                Data.ElementMinSi = batchMaster.ElementMinSi;
                Data.ElementMinMn = batchMaster.ElementMinMn;
                Data.ElementMinP = batchMaster.ElementMinP;
                Data.ElementMinS = batchMaster.ElementMinS;
                Data.ElementMinNi = batchMaster.ElementMinNi;
                Data.ElementMinCr = batchMaster.ElementMinCr;
                Data.ElementMinMo = batchMaster.ElementMinMo;
                Data.ElementMinCu = batchMaster.ElementMinCu;
                Data.ElementMaxC = batchMaster.ElementMaxC;
                Data.ElementMaxSi = batchMaster.ElementMaxSi;
                Data.ElementMaxMn = batchMaster.ElementMaxMn;
                Data.ElementMaxP = batchMaster.ElementMaxP;
                Data.ElementMaxS = batchMaster.ElementMaxS;
                Data.ElementMaxNi = batchMaster.ElementMaxNi;
                Data.ElementMaxCr = batchMaster.ElementMaxCr;
                Data.ElementMaxMo = batchMaster.ElementMaxMo;
                Data.ElementMaxCu = batchMaster.ElementMaxCu;
                Data.TestMinUts = batchMaster.TestMinUts;
                Data.TestMinYs = batchMaster.TestMinYs;
                Data.TestMinElongation = batchMaster.TestMinElongation;
                Data.TestMaxUts = batchMaster.TestMaxUts;
                Data.TestMaxYs = batchMaster.TestMaxYs;
                Data.TestMaxElongation = batchMaster.TestMaxElongation;
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
                    Data.ElementMinC = batchMaster.ElementMinC;
                    Data.ElementMinSi = batchMaster.ElementMinSi;
                    Data.ElementMinMn = batchMaster.ElementMinMn;
                    Data.ElementMinP = batchMaster.ElementMinP;
                    Data.ElementMinS = batchMaster.ElementMinS;
                    Data.ElementMinNi = batchMaster.ElementMinNi;
                    Data.ElementMinCr = batchMaster.ElementMinCr;
                    Data.ElementMinMo = batchMaster.ElementMinMo;
                    Data.ElementMinCu = batchMaster.ElementMinCu;
                    Data.ElementMaxC = batchMaster.ElementMaxC;
                    Data.ElementMaxSi = batchMaster.ElementMaxSi;
                    Data.ElementMaxMn = batchMaster.ElementMaxMn;
                    Data.ElementMaxP = batchMaster.ElementMaxP;
                    Data.ElementMaxS = batchMaster.ElementMaxS;
                    Data.ElementMaxNi = batchMaster.ElementMaxNi;
                    Data.ElementMaxCr = batchMaster.ElementMaxCr;
                    Data.ElementMaxMo = batchMaster.ElementMaxMo;
                    Data.ElementMaxCu = batchMaster.ElementMaxCu;
                    Data.TestMinUts = batchMaster.TestMinUts;
                    Data.TestMinYs = batchMaster.TestMinYs;
                    Data.TestMinElongation = batchMaster.TestMinElongation;
                    Data.TestMaxUts = batchMaster.TestMaxUts;
                    Data.TestMaxYs = batchMaster.TestMaxYs;
                    Data.TestMaxElongation = batchMaster.TestMaxElongation;
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
                Data.ElementMinC = batchMaster.ElementMinC;
                Data.ElementMinSi = batchMaster.ElementMinSi;
                Data.ElementMinMn = batchMaster.ElementMinMn;
                Data.ElementMinP = batchMaster.ElementMinP;
                Data.ElementMinS = batchMaster.ElementMinS;
                Data.ElementMinNi = batchMaster.ElementMinNi;
                Data.ElementMinCr = batchMaster.ElementMinCr;
                Data.ElementMinMo = batchMaster.ElementMinMo;
                Data.ElementMinCu = batchMaster.ElementMinCu;
                Data.ElementMaxC = batchMaster.ElementMaxC;
                Data.ElementMaxSi = batchMaster.ElementMaxSi;
                Data.ElementMaxMn = batchMaster.ElementMaxMn;
                Data.ElementMaxP = batchMaster.ElementMaxP;
                Data.ElementMaxS = batchMaster.ElementMaxS;
                Data.ElementMaxNi = batchMaster.ElementMaxNi;
                Data.ElementMaxCr = batchMaster.ElementMaxCr;
                Data.ElementMaxMo = batchMaster.ElementMaxMo;
                Data.ElementMaxCu = batchMaster.ElementMaxCu;
                Data.TestMinUts = batchMaster.TestMinUts;
                Data.TestMinYs = batchMaster.TestMinYs;
                Data.TestMinElongation = batchMaster.TestMinElongation;
                Data.TestMaxUts = batchMaster.TestMaxUts;
                Data.TestMaxYs = batchMaster.TestMaxYs;
                Data.TestMaxElongation = batchMaster.TestMaxElongation;
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
                        Data.ElementMinC = batchMaster.ElementMinC;
                        Data.ElementMinSi = batchMaster.ElementMinSi;
                        Data.ElementMinMn = batchMaster.ElementMinMn;
                        Data.ElementMinP = batchMaster.ElementMinP;
                        Data.ElementMinS = batchMaster.ElementMinS;
                        Data.ElementMinNi = batchMaster.ElementMinNi;
                        Data.ElementMinCr = batchMaster.ElementMinCr;
                        Data.ElementMinMo = batchMaster.ElementMinMo;
                        Data.ElementMinCu = batchMaster.ElementMinCu;
                        Data.ElementMaxC = batchMaster.ElementMaxC;
                        Data.ElementMaxSi = batchMaster.ElementMaxSi;
                        Data.ElementMaxMn = batchMaster.ElementMaxMn;
                        Data.ElementMaxP = batchMaster.ElementMaxP;
                        Data.ElementMaxS = batchMaster.ElementMaxS;
                        Data.ElementMaxNi = batchMaster.ElementMaxNi;
                        Data.ElementMaxCr = batchMaster.ElementMaxCr;
                        Data.ElementMaxMo = batchMaster.ElementMaxMo;
                        Data.ElementMaxCu = batchMaster.ElementMaxCu;
                        Data.TestMinUts = batchMaster.TestMinUts;
                        Data.TestMinYs = batchMaster.TestMinYs;
                        Data.TestMinElongation = batchMaster.TestMinElongation;
                        Data.TestMaxUts = batchMaster.TestMaxUts;
                        Data.TestMaxYs = batchMaster.TestMaxYs;
                        Data.TestMaxElongation = batchMaster.TestMaxElongation;
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