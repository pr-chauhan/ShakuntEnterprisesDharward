using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShakuntEnterprisesDharward.Models;
using ShakuntEnterprises.Comman;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using NToastNotify;

namespace ShakuntEnterprises.Controllers
{
    public class MainNavigationBarsController : Controller
    {
        private readonly ShakuntEnterprisesDharwardContext _context;
        private CommanClass commanClass;
        private IConfiguration configuration;
        private readonly IToastNotification _toastNotification;
        public MainNavigationBarsController(ShakuntEnterprisesDharwardContext context, IConfiguration _configuration, IToastNotification toastNotification)
        {
            _context = context;
            configuration = _configuration;
            _toastNotification = toastNotification;
            commanClass = new CommanClass(context,configuration);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //HttpContext.Session.GetString("lid")
            ViewBag.Modules = commanClass.getModlueList(HttpContext.Session.GetString("lid"));
            ViewBag.Menus = commanClass.getModlueMenuList(HttpContext.Session.GetString("lid"));
            ViewBag.UniqueMenus = _context.MainNavigationBars.Where(x => x.UserId == (HttpContext.Session.GetString("lid")) && x.SubMenuId == null).OrderBy(x => x.MenuId).ToList()
                .Select(x => new
                {
                    x.MenuId,
                    x.MenuName
                }).Distinct().ToList();
            ViewBag.Users = commanClass.getAllUserList();
            ViewBag.Controllers = _context.MainNavigationBars.Where(x => x.UserId == (HttpContext.Session.GetString("lid")) && x.SubMenuId == null).OrderBy(x => x.MenuId).ToList()
                .Select(x => new
                {
                    x.ContollerName,
                }).Distinct().ToList();
            ViewBag.Actions = _context.MainNavigationBars.Where(x => x.UserId == (HttpContext.Session.GetString("lid")) && x.SubMenuId == null).OrderBy(x => x.MenuId).ToList()
                .Select(x => new
                {
                    x.ActionName,
                }).Distinct().ToList();

            ViewBag.CDT = DateTime.Now.ToString();
        }

        // GET: MainNavigationBars
        [HttpGet]
        public JsonResult GetMenulistofMenu(int ModuleId)
        {

            var UniqueMenus = _context.MainNavigationBars.Where(x => x.ModuleId == ModuleId && x.UserId == (HttpContext.Session.GetString("lid")) && x.SubMenuId == null).OrderBy(x => x.MenuId).ToList()
                .Select(x => new
                {
                    x.MenuId,
                    x.MenuName
                }).Distinct().ToList();
            var jsondata = JsonSerializer.Serialize(UniqueMenus);
            return Json(jsondata);
        }
        [HttpGet]
        public JsonResult GetMenulistofController(int ModuleId,int MenuId)
        {

            var UniqueMenus = _context.MainNavigationBars.Where(x =>  x.ModuleId==ModuleId && x.MenuId == MenuId && x.UserId == (HttpContext.Session.GetString("lid")) && x.SubMenuId == null).OrderBy(x => x.MenuId).ToList()
                .Select(x => new
                {
                    x.ContollerName,
                }).Distinct().ToList();
            var jsondata = JsonSerializer.Serialize(UniqueMenus);
            return Json(jsondata);
        }
        [HttpGet]
        public JsonResult GetMenulistofAction(int ModuleId, int MenuId,string sController)
        {

            var UniqueMenus = _context.MainNavigationBars.Where(x => x.ModuleId == ModuleId && x.MenuId == MenuId && x.ContollerName == sController && x.UserId == (HttpContext.Session.GetString("lid")) && x.SubMenuId == null).OrderBy(x => x.MenuId).ToList()
                .Select(x => new
                {
                    x.ActionName,
                }).Distinct().ToList();
            var jsondata = JsonSerializer.Serialize(UniqueMenus);
            return Json(jsondata);
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            return _context.MainNavigationBars != null ? 
                          View(await _context.MainNavigationBars.ToListAsync()) :
                          Problem("Entity set 'ShakuntEnterprisesDharwardContext.MainNavigationBars'  is null.");
        }

        // GET: MainNavigationBars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            if (id == null || _context.MainNavigationBars == null)
            {
                return NotFound();
            }

            var mainNavigationBar = await _context.MainNavigationBars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainNavigationBar == null)
            {
                return NotFound();
            }

            return View(mainNavigationBar);
        }

        // GET: MainNavigationBars/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            return View();
        }

        // POST: MainNavigationBars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( MainNavigationBar mainNavigationBar)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            if (ModelState.IsValid)
            {
                _context.Add(mainNavigationBar);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage(mainNavigationBar.SubMenuName + " Created successfully!");
                return RedirectToAction(nameof(Index));
            }
            return View(mainNavigationBar);
        }

        // GET: MainNavigationBars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            if (id == null || _context.MainNavigationBars == null)
            {
                return NotFound();
            }

            var mainNavigationBar = await _context.MainNavigationBars.FindAsync(id);
            if (mainNavigationBar == null)
            {
                return NotFound();
            }
            return View(mainNavigationBar);
        }

        // POST: MainNavigationBars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,MainNavigationBar mainNavigationBar)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            if (id != mainNavigationBar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainNavigationBar);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage(mainNavigationBar.SubMenuName + " Updated successfully!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainNavigationBarExists(mainNavigationBar.Id))
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
            return View(mainNavigationBar);
        }

        // GET: MainNavigationBars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            if (id == null || _context.MainNavigationBars == null)
            {
                return NotFound();
            }

            var mainNavigationBar = await _context.MainNavigationBars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainNavigationBar == null)
            {
                return NotFound();
            }

            return View(mainNavigationBar);
        }

        // POST: MainNavigationBars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            if (_context.MainNavigationBars == null)
            {
                return Problem("Entity set 'ShakuntEnterprisesDharwardContext.MainNavigationBars'  is null.");
            }
            var mainNavigationBar = await _context.MainNavigationBars.FindAsync(id);
            if (mainNavigationBar != null)
            {
                _context.MainNavigationBars.Remove(mainNavigationBar);
            }
            
            await _context.SaveChangesAsync();
            _toastNotification.AddSuccessToastMessage(mainNavigationBar.SubMenuName + " Deleted successfully!");
            return RedirectToAction(nameof(Index));
        }

        private bool MainNavigationBarExists(int id)
        {
          return (_context.MainNavigationBars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
