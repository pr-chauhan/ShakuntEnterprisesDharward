﻿using Microsoft.AspNetCore.Mvc;
using ShakuntEnterprisesDharward.Models;
using System.Data;
using ShakuntEnterprises.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShakuntEnterprises.Comman;
using Microsoft.AspNetCore.Mvc.Filters;
using NToastNotify;

namespace ShakuntEnterprises.Controllers
{
    public class SizeMasterController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShakuntEnterprisesDharwardContext _context;
        private CommanClass commanClass;
        private IConfiguration configuration;
        // GET: SizeMasterController
        private readonly IToastNotification _toastNotification;
        public SizeMasterController(ILogger<HomeController> logger, ShakuntEnterprisesDharwardContext enterprisesContext, IConfiguration _configuration, IToastNotification toastNotification)
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

        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

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
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

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
                Data.SizeStandardValue = sizeMaster.SizeStandardValue;
                Data.SizeActualValue = sizeMaster.SizeActualValue;
                Data.CoatingStandardValue = sizeMaster.CoatingStandardValue;
                Data.CoatingActualValue = sizeMaster.CoatingActualValue;
                Data.UtswireStandardValue = sizeMaster.UtswireStandardValue;
                Data.UtswireActualValue = sizeMaster.UtswireActualValue;
                Data.CastDiaStandardValue = sizeMaster.CastDiaStandardValue;
                Data.CastDiaActualValue = sizeMaster.CastDiaActualValue;
                Data.HelixStandardValue = sizeMaster.HelixStandardValue;
                Data.HelixActualValue = sizeMaster.HelixActualValue;
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
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            return View();
        }

        // POST: SizeMasterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SizeMasterModel sizeMaster)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            try
            {
                if (ModelState.IsValid)
                {
                    var Data = new SizeMaster();
                    Data.Size = sizeMaster.Size;
                    Data.Apms = sizeMaster.Apms;
                    Data.Volts = sizeMaster.Volts;
                    Data.TravelSpeed = sizeMaster.TravelSpeed;
                    Data.SizeStandardValue = sizeMaster.SizeStandardValue;
                    Data.SizeActualValue = sizeMaster.SizeActualValue;
                    Data.CoatingStandardValue = sizeMaster.CoatingStandardValue;
                    Data.CoatingActualValue = sizeMaster.CoatingActualValue;
                    Data.UtswireStandardValue = sizeMaster.UtswireStandardValue;
                    Data.UtswireActualValue = sizeMaster.UtswireActualValue;
                    Data.CastDiaStandardValue = sizeMaster.CastDiaStandardValue;
                    Data.CastDiaActualValue = sizeMaster.CastDiaActualValue;
                    Data.HelixStandardValue = sizeMaster.HelixStandardValue;
                    Data.HelixActualValue = sizeMaster.HelixActualValue;
                    Data.CreatedDate = sizeMaster.CreatedDate;
                    Data.CreatedBy = sizeMaster.CreatedBy;
                    Data.ModifiedDate = sizeMaster.ModifiedDate;
                    Data.ModifiedBy = sizeMaster.ModifiedBy;
                    _context.Add(Data);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage(sizeMaster.Size + " Created successfully!");
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
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

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
                Data.SizeStandardValue = sizeMaster.SizeStandardValue;
                Data.SizeActualValue = sizeMaster.SizeActualValue;
                Data.CoatingStandardValue = sizeMaster.CoatingStandardValue;
                Data.CoatingActualValue = sizeMaster.CoatingActualValue;
                Data.UtswireStandardValue = sizeMaster.UtswireStandardValue;
                Data.UtswireActualValue = sizeMaster.UtswireActualValue;
                Data.CastDiaStandardValue = sizeMaster.CastDiaStandardValue;
                Data.CastDiaActualValue = sizeMaster.CastDiaActualValue;
                Data.HelixStandardValue = sizeMaster.HelixStandardValue;
                Data.HelixActualValue = sizeMaster.HelixActualValue;
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
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

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
                        Data.SizeStandardValue = sizeMaster.SizeStandardValue;
                        Data.SizeActualValue = sizeMaster.SizeActualValue;
                        Data.CoatingStandardValue = sizeMaster.CoatingStandardValue;
                        Data.CoatingActualValue = sizeMaster.CoatingActualValue;
                        Data.UtswireStandardValue = sizeMaster.UtswireStandardValue;
                        Data.UtswireActualValue = sizeMaster.UtswireActualValue;
                        Data.CastDiaStandardValue = sizeMaster.CastDiaStandardValue;
                        Data.CastDiaActualValue = sizeMaster.CastDiaActualValue;
                        Data.HelixStandardValue = sizeMaster.HelixStandardValue;
                        Data.HelixActualValue = sizeMaster.HelixActualValue;
                        Data.CreatedDate = sizeMaster.CreatedDate;
                        Data.CreatedBy = sizeMaster.CreatedBy;
                        Data.ModifiedDate = sizeMaster.ModifiedDate;
                        Data.ModifiedBy = sizeMaster.ModifiedBy;
                    }
                    _context.Update(Data);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage(sizeMaster.Size + " Updated successfully!");
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
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            return View();
        }


        // POST: SizeMasterController/Delete/5
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
            return (_context.SizeMasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

