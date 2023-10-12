using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShakuntEnterprises.Models;
using ShakuntEnterprises.Comman;
using Microsoft.AspNetCore.Mvc.Filters;
using NToastNotify;

namespace ShakuntEnterprises.Controllers
{
    public class MainModuleBarsController : Controller
    {
        private readonly ShakuntEnterprisesContext _context;
        private CommanClass commanClass;
        private IConfiguration configuration;
        private readonly IToastNotification _toastNotification;
        public MainModuleBarsController(ShakuntEnterprisesContext context, IConfiguration _configuration)
        {
            _context = context;
            configuration = _configuration;
            commanClass = new CommanClass(context,configuration);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //ViewBag.Modules = commanClass.getAllModlueList();
            ViewBag.Modules = commanClass.getModlueList(HttpContext.Session.GetString("lid"));
            ViewBag.Menus = commanClass.getModlueMenuList(HttpContext.Session.GetString("lid"));
            ViewBag.Users = commanClass.getAllUserList();
            ViewBag.Controllers = commanClass.getAllControllerList();
            ViewBag.Actions = commanClass.getAllActionList();
            ViewBag.CDT = DateTime.Now.ToString();
        }

        // GET: MainModuleBars
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            return _context.MainModuleBars != null ? 
                          View(await _context.MainModuleBars.ToListAsync()) :
                          Problem("Entity set 'ShakuntEnterprisesContext.MainModuleBars'  is null.");
        }

        // GET: MainModuleBars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            if (id == null || _context.MainModuleBars == null)
            {
                return NotFound();
            }

            var mainModuleBar = await _context.MainModuleBars
                .FirstOrDefaultAsync(m => m.ModuleId == id);
            if (mainModuleBar == null)
            {
                return NotFound();
            }

            return View(mainModuleBar);
        }

        // GET: MainModuleBars/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            return View();
        }

        // POST: MainModuleBars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( MainModuleBar mainModuleBar)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            if (ModelState.IsValid)
            {
                _context.Add(mainModuleBar);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage(mainModuleBar.ModuleName + " Created successfully!");
                return RedirectToAction(nameof(Index));
            }
            return View(mainModuleBar);
        }

        // GET: MainModuleBars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            if (id == null || _context.MainModuleBars == null)
            {
                return NotFound();
            }

            var mainModuleBar = await _context.MainModuleBars.FindAsync(id);
            if (mainModuleBar == null)
            {
                return NotFound();
            }
            return View(mainModuleBar);
        }

        // POST: MainModuleBars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MainModuleBar mainModuleBar)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");
            if (id != mainModuleBar.ModuleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainModuleBar);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage(mainModuleBar.ModuleName + " Updated successfully!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainModuleBarExists(mainModuleBar.Id))
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
            return View(mainModuleBar);
        }

        // GET: MainModuleBars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");
            if (id == null || _context.MainModuleBars == null)
            {
                return NotFound();
            }

            var mainModuleBar = await _context.MainModuleBars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainModuleBar == null)
            {
                return NotFound();
            }

            return View(mainModuleBar);
        }

        // POST: MainModuleBars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            if (_context.MainModuleBars == null)
            {
                return Problem("Entity set 'ShakuntEnterprisesContext.MainModuleBars'  is null.");
            }
            var mainModuleBar = await _context.MainModuleBars.FindAsync(id);
            if (mainModuleBar != null)
            {
                _context.MainModuleBars.Remove(mainModuleBar);
            }
            
            await _context.SaveChangesAsync();
            _toastNotification.AddSuccessToastMessage(mainModuleBar.ModuleName + " Deleted successfully!");
            return RedirectToAction(nameof(Index));
        }

        private bool MainModuleBarExists(int id)
        {
          return (_context.MainModuleBars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
