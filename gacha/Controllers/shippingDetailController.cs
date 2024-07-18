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
    public class shippingDetailController : Controller
    {
        private readonly gachaContext _context;

        public shippingDetailController(gachaContext context)
        {
            _context = context;
        }

        // GET: shippingDetail
        public async Task<IActionResult> Index()
        {
            var gachaContext = _context.shippingDetail.Include(s => s.bag).Include(s => s.shipping);
            return View(await gachaContext.ToListAsync());
        }

        // GET: shippingDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingDetail = await _context.shippingDetail
                .Include(s => s.bag)
                .Include(s => s.shipping)
                .FirstOrDefaultAsync(m => m.id == id);
            if (shippingDetail == null)
            {
                return NotFound();
            }

            return View(shippingDetail);
        }

        // GET: shippingDetail/Create
        public IActionResult Create()
        {
            ViewData["bagId"] = new SelectList(_context.bag, "id", "gachaStatus");
            ViewData["shippingId"] = new SelectList(_context.shipping, "id", "contactPhone");
            return View();
        }

        // POST: shippingDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,shippingId,bagId,quantity")] shippingDetail shippingDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shippingDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["bagId"] = new SelectList(_context.bag, "id", "gachaStatus", shippingDetail.bagId);
            ViewData["shippingId"] = new SelectList(_context.shipping, "id", "contactPhone", shippingDetail.shippingId);
            return View(shippingDetail);
        }

        // GET: shippingDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingDetail = await _context.shippingDetail.FindAsync(id);
            if (shippingDetail == null)
            {
                return NotFound();
            }
            ViewData["bagId"] = new SelectList(_context.bag, "id", "gachaStatus", shippingDetail.bagId);
            ViewData["shippingId"] = new SelectList(_context.shipping, "id", "contactPhone", shippingDetail.shippingId);
            return View(shippingDetail);
        }

        // POST: shippingDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,shippingId,bagId,quantity")] shippingDetail shippingDetail)
        {
            if (id != shippingDetail.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shippingDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!shippingDetailExists(shippingDetail.id))
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
            ViewData["bagId"] = new SelectList(_context.bag, "id", "gachaStatus", shippingDetail.bagId);
            ViewData["shippingId"] = new SelectList(_context.shipping, "id", "contactPhone", shippingDetail.shippingId);
            return View(shippingDetail);
        }

        // GET: shippingDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingDetail = await _context.shippingDetail
                .Include(s => s.bag)
                .Include(s => s.shipping)
                .FirstOrDefaultAsync(m => m.id == id);
            if (shippingDetail == null)
            {
                return NotFound();
            }

            return View(shippingDetail);
        }

        // POST: shippingDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shippingDetail = await _context.shippingDetail.FindAsync(id);
            if (shippingDetail != null)
            {
                _context.shippingDetail.Remove(shippingDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool shippingDetailExists(int id)
        {
            return _context.shippingDetail.Any(e => e.id == id);
        }
    }
}
