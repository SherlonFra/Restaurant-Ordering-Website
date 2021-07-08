using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantManager.Data;
using RestaurantManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantManager.Controllers
{
    [Authorize(Roles = "Administrator")]

    public class MenuitemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuitemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Menuitems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Menuitems.Include(m => m.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Menuitems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.Menuitems
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (menuitem == null)
            {
                return NotFound();
            }

            return View(menuitem);
        }

        // GET: Menuitems/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Menuitems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuItemId,Name,Price,Description,CategoryId")] Menuitem menuitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", menuitem.CategoryId);
            return View(menuitem);
        }

        // GET: Menuitems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.Menuitems.FindAsync(id);
            if (menuitem == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", menuitem.CategoryId);
            return View(menuitem);
        }

        // POST: Menuitems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuItemId,Name,Price,Description,CategoryId")] Menuitem menuitem)
        {
            if (id != menuitem.MenuItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuitemExists(menuitem.MenuItemId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", menuitem.CategoryId);
            return View(menuitem);
        }

        // GET: Menuitems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.Menuitems
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (menuitem == null)
            {
                return NotFound();
            }

            return View(menuitem);
        }

        // POST: Menuitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuitem = await _context.Menuitems.FindAsync(id);
            _context.Menuitems.Remove(menuitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuitemExists(int id)
        {
            return _context.Menuitems.Any(e => e.MenuItemId == id);
        }
    }
}
