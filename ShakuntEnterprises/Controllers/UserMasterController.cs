using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShakuntEnterprisesDharward.Models;
using Microsoft.EntityFrameworkCore;
using ShakuntEnterprises.Comman;
using Microsoft.AspNetCore.Mvc.Filters;
using NToastNotify;

namespace ShakuntEnterprises.Controllers
{
    public class UserMasterController : Controller
    {
        private readonly ShakuntEnterprisesDharwardContext _context;
        private IConfiguration configuration;
        private CommanClass commanClass;
        private readonly IToastNotification _toastNotification;
        public UserMasterController(ShakuntEnterprisesDharwardContext context, IConfiguration _configuration, IToastNotification toastNotification)
        {
            _context = context;
            configuration = _configuration;
            _toastNotification = toastNotification;
            commanClass = new CommanClass(context, configuration);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.Modules = commanClass.getModlueList(HttpContext.Session.GetString("lid"));
            ViewBag.Menus = commanClass.getModlueMenuList(HttpContext.Session.GetString("lid"));
        }


        // GET: UserMasters
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login","Home");

            return View(await _context.UserMasters.ToListAsync());
        }

        // GET: UserMasters/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var userMaster = await _context.UserMasters
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userMaster == null)
            {
                return NotFound();
            }

            return View(userMaster);
        }

        // GET: UserMasters/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login", "Home");

            ViewBag.LID = HttpContext.Session.GetString("lid");
            ViewBag.CDT = DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }

        // POST: UserMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserMaster userMaster)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login", "Home");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(userMaster);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage(userMaster.UserId + " Created successfully!");
                }
                catch(Exception ex)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(userMaster);
        }

        // GET: UserMasters/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login", "Home");

            ViewBag.LID = HttpContext.Session.GetString("lid");
            ViewBag.CDT = DateTime.Now.ToString("yyyy-MM-dd");
            if (id == null)
            {
                return NotFound();
            }

            var userMaster = await _context.UserMasters.FindAsync(id);
            if (userMaster == null)
            {
                return NotFound();
            }
            return View(userMaster);
        }

        // POST: UserMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserMaster userMaster)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login", "Home");

            if (id != userMaster.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userMaster);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage(userMaster.UserId + " Updated successfully!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserMasterExists(userMaster.UserId))
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
            return View(userMaster);
        }

        // GET: UserMasters/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var userMaster = await _context.UserMasters
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userMaster == null)
            {
                return NotFound();
            }

            return View(userMaster);
        }

        // POST: UserMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (HttpContext.Session.GetString("lid") == null)
                return RedirectToAction("Login", "Home");

            var userMaster = await _context.UserMasters.FindAsync(id);
            _context.UserMasters.Remove(userMaster);
            await _context.SaveChangesAsync();
            _toastNotification.AddSuccessToastMessage(userMaster.UserId + " Deleted successfully!");
            return RedirectToAction(nameof(Index));
        }

        private bool UserMasterExists(string id)
        {
            return _context.UserMasters.Any(e => e.UserId == id);
        }
    }
}
