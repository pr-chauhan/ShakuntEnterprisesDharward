﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShakuntEnterprises.Models;
using ShakuntEnterprises.Comman;
using Microsoft.AspNetCore.Mvc.Filters;
namespace ShakuntEnterprises.Controllers
{
    public class MainModuleBarsController : Controller
    {
        private readonly ShakuntEnterprisesContext _context;
        private CommanClass commanClass;
        public MainModuleBarsController(ShakuntEnterprisesContext context)
        {
            _context = context;
            commanClass = new CommanClass(context);
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
              return _context.MainModuleBars != null ? 
                          View(await _context.MainModuleBars.ToListAsync()) :
                          Problem("Entity set 'ShakuntEnterprisesContext.MainModuleBars'  is null.");
        }

        // GET: MainModuleBars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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
            return View();
        }

        // POST: MainModuleBars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( MainModuleBar mainModuleBar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainModuleBar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainModuleBar);
        }

        // GET: MainModuleBars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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
            return RedirectToAction(nameof(Index));
        }

        private bool MainModuleBarExists(int id)
        {
          return (_context.MainModuleBars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}