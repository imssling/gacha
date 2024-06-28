using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gacha.Models;

namespace gacha.Controllers
{
    public class gachaThemeController : Controller
    {
        private readonly gachaContext _context;

        public gachaThemeController(gachaContext context)
        {
            _context = context;
        }

        // GET: gachaTheme
        public async Task<IActionResult> Index()
        {
            return View(_context.gachaTheme);
        }

        // GET: gachaTheme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaTheme = await _context.gachaTheme
                .FirstOrDefaultAsync(m => m.id == id);
            if (gachaTheme == null)
            {
                return NotFound();
            }

            return View(gachaTheme);
        }

        // GET: gachaTheme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: gachaTheme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,themeName")] gachaTheme gachaTheme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gachaTheme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gachaTheme);
        }

        // GET: gachaTheme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaTheme = await _context.gachaTheme.FindAsync(id);
            if (gachaTheme == null)
            {
                return NotFound();
            }
            return View(gachaTheme);
        }

        // POST: gachaTheme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,themeName")] gachaTheme gachaTheme)
        {
            if (id != gachaTheme.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gachaTheme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!gachaThemeExists(gachaTheme.id))
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
            return View(gachaTheme);
        }

        // GET: gachaTheme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaTheme = await _context.gachaTheme
                .FirstOrDefaultAsync(m => m.id == id);
            if (gachaTheme == null)
            {
                return NotFound();
            }

            return View(gachaTheme);
        }

        // POST: gachaTheme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gachaTheme = await _context.gachaTheme.FindAsync(id);
            if (gachaTheme != null)
            {
                _context.gachaTheme.Remove(gachaTheme);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool gachaThemeExists(int id)
        {
            return _context.gachaTheme.Any(e => e.id == id);
        }
    }
}
