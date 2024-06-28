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
    public class gachaMachineController : Controller
    {
        private readonly gachaContext _context;

        public gachaMachineController(gachaContext context)
        {
            _context = context;
        }

        // GET: gachaMachine
        public async Task<IActionResult> Index()
        {
            var gachaContext = _context.gachaMachine.Include(g => g.theme);
            return View(await gachaContext.ToListAsync());
        }

        // GET: gachaMachine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaMachine = await _context.gachaMachine
                .Include(g => g.theme)
                .FirstOrDefaultAsync(m => m.id == id);
            if (gachaMachine == null)
            {
                return NotFound();
            }

            return View(gachaMachine);
        }

        // GET: gachaMachine/Create
        public IActionResult Create()
        {
            ViewData["themeId"] = new SelectList(_context.gachaTheme, "id", "themeName");
            return View();
        }

        // POST: gachaMachine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,themeId,machineName,machineDescription,machinePictureName,createTime,price")] gachaMachine gachaMachine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gachaMachine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["themeId"] = new SelectList(_context.gachaTheme, "id", "themeName", gachaMachine.themeId);
            return View(gachaMachine);
        }

        // GET: gachaMachine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaMachine = await _context.gachaMachine.FindAsync(id);
            if (gachaMachine == null)
            {
                return NotFound();
            }
            ViewData["themeId"] = new SelectList(_context.gachaTheme, "id", "themeName", gachaMachine.themeId);
            return View(gachaMachine);
        }

        // POST: gachaMachine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,themeId,machineName,machineDescription,machinePictureName,createTime,price")] gachaMachine gachaMachine)
        {
            if (id != gachaMachine.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gachaMachine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!gachaMachineExists(gachaMachine.id))
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
            ViewData["themeId"] = new SelectList(_context.gachaTheme, "id", "themeName", gachaMachine.themeId);
            return View(gachaMachine);
        }

        // GET: gachaMachine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaMachine = await _context.gachaMachine
                .Include(g => g.theme)
                .FirstOrDefaultAsync(m => m.id == id);
            if (gachaMachine == null)
            {
                return NotFound();
            }

            return View(gachaMachine);
        }

        // POST: gachaMachine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gachaMachine = await _context.gachaMachine.FindAsync(id);
            if (gachaMachine != null)
            {
                _context.gachaMachine.Remove(gachaMachine);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool gachaMachineExists(int id)
        {
            return _context.gachaMachine.Any(e => e.id == id);
        }
    }
}
