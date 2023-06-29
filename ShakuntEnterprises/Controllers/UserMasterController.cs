using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShakuntEnterprises.Models;
using Microsoft.EntityFrameworkCore;
using ShakuntEnterprises.Comman;
using Microsoft.AspNetCore.Mvc.Filters;
namespace ShakuntEnterprises.Controllers
{
    public class UserMasterController : Controller
    {
        private readonly ShakuntEnterprisesContext _context;
        private IConfiguration configuration;
        private CommanClass commanClass;
        public UserMasterController(ShakuntEnterprisesContext context, IConfiguration _configuration)
        {
            _context = context;
            configuration = _configuration;
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
            return View(await _context.UserMasters.ToListAsync());
        }

        // GET: UserMasters/Details/5
        public async Task<IActionResult> Details(string id)
        {
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
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(userMaster);
                    await _context.SaveChangesAsync();
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
            var userMaster = await _context.UserMasters.FindAsync(id);
            _context.UserMasters.Remove(userMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserMasterExists(string id)
        {
            return _context.UserMasters.Any(e => e.UserId == id);
        }
    }
}
