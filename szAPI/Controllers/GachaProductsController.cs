using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using szAPI.Models;

namespace szAPI.Controllers
{
    public class GachaProductsController : Controller
    {
        private readonly gachaContext _context;

        public GachaProductsController(gachaContext context)
        {
            _context = context;
        }

        // GET: GachaProducts
        public async Task<IActionResult> Index()
        {
            var gachaContext = _context.GachaProducts.Include(g => g.Machine);
            return View(await gachaContext.ToListAsync());
        }

        // GET: GachaProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaProduct = await _context.GachaProducts
                .Include(g => g.Machine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gachaProduct == null)
            {
                return NotFound();
            }

            return View(gachaProduct);
        }

        // GET: GachaProducts/Create
        public IActionResult Create()
        {
            ViewData["MachineId"] = new SelectList(_context.GachaMachines, "Id", "MachineName");
            return View();
        }

        // POST: GachaProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MachineId,ProductName,Stock,ProductPictureName,CreateTime")] GachaProduct gachaProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gachaProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MachineId"] = new SelectList(_context.GachaMachines, "Id", "MachineName", gachaProduct.MachineId);
            return View(gachaProduct);
        }

        // GET: GachaProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaProduct = await _context.GachaProducts.FindAsync(id);
            if (gachaProduct == null)
            {
                return NotFound();
            }
            ViewData["MachineId"] = new SelectList(_context.GachaMachines, "Id", "MachineName", gachaProduct.MachineId);
            return View(gachaProduct);
        }

        // POST: GachaProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MachineId,ProductName,Stock,ProductPictureName,CreateTime")] GachaProduct gachaProduct)
        {
            if (id != gachaProduct.Id)
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
                    if (!GachaProductExists(gachaProduct.Id))
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
            ViewData["MachineId"] = new SelectList(_context.GachaMachines, "Id", "MachineName", gachaProduct.MachineId);
            return View(gachaProduct);
        }

        // GET: GachaProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaProduct = await _context.GachaProducts
                .Include(g => g.Machine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gachaProduct == null)
            {
                return NotFound();
            }

            return View(gachaProduct);
        }

        // POST: GachaProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gachaProduct = await _context.GachaProducts.FindAsync(id);
            if (gachaProduct != null)
            {
                _context.GachaProducts.Remove(gachaProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GachaProductExists(int id)
        {
            return _context.GachaProducts.Any(e => e.Id == id);
        }
    }
}
