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
    public class gachaProductController : Controller
    {
        private readonly gachaContext _context;

        public gachaProductController(gachaContext context)
        {
            _context = context;
        }

        // GET: gachaProduct
        public async Task<IActionResult> Index()
        {
            var gachaContext = _context.gachaProduct.Include(g => g.machine);
            return View(await gachaContext.ToListAsync());
        }

        // GET: gachaProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaProduct = await _context.gachaProduct
                .Include(g => g.machine)
                .FirstOrDefaultAsync(m => m.id == id);
            if (gachaProduct == null)
            {
                return NotFound();
            }

            return View(gachaProduct);
        }

        // GET: gachaProduct/Create
        public IActionResult Create()
        {
            ViewData["machineId"] = new SelectList(_context.gachaMachine, "id", "machineName");
            return View();
        }

        // POST: gachaProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,machineId,productName,stock,productPictureName,createTime")] gachaProduct gachaProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gachaProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["machineId"] = new SelectList(_context.gachaMachine, "id", "machineName", gachaProduct.machineId);
            return View(gachaProduct);
        }

        // GET: gachaProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaProduct = await _context.gachaProduct.FindAsync(id);
            if (gachaProduct == null)
            {
                return NotFound();
            }
            ViewData["machineId"] = new SelectList(_context.gachaMachine, "id", "machineName", gachaProduct.machineId);
            return View(gachaProduct);
        }

        // POST: gachaProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,machineId,productName,stock,productPictureName,createTime")] gachaProduct gachaProduct)
        {
            if (id != gachaProduct.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gachaProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!gachaProductExists(gachaProduct.id))
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
            ViewData["machineId"] = new SelectList(_context.gachaMachine, "id", "machineName", gachaProduct.machineId);
            return View(gachaProduct);
        }

        // GET: gachaProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaProduct = await _context.gachaProduct
                .Include(g => g.machine)
                .FirstOrDefaultAsync(m => m.id == id);
            if (gachaProduct == null)
            {
                return NotFound();
            }

            return View(gachaProduct);
        }

        // POST: gachaProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gachaProduct = await _context.gachaProduct.FindAsync(id);
            if (gachaProduct != null)
            {
                _context.gachaProduct.Remove(gachaProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool gachaProductExists(int id)
        {
            return _context.gachaProduct.Any(e => e.id == id);
        }
    }
}
