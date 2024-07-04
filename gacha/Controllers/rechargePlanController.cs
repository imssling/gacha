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
    public class rechargePlanController : Controller
    {
        private readonly gachaContext _context;

        public rechargePlanController(gachaContext context)
        {
            _context = context;
        }

        // GET: rechargePlan
        public async Task<IActionResult> Index()
        {
            return View(_context.rechargePlan);
        }

        // GET: rechargePlan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rechargePlan = await _context.rechargePlan
                .FirstOrDefaultAsync(m => m.id == id);
            if (rechargePlan == null)
            {
                return NotFound();
            }

            return View(rechargePlan);
        }

        // GET: rechargePlan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: rechargePlan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,point,price,status,createdAt,updatedAt")] rechargePlan rechargePlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rechargePlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rechargePlan);
        }

        // GET: rechargePlan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rechargePlan = await _context.rechargePlan.FindAsync(id);
            if (rechargePlan == null)
            {
                return NotFound();
            }
            return View(rechargePlan);
        }

        // POST: rechargePlan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,point,price,status,createdAt,updatedAt")] rechargePlan rechargePlan)
        {
            if (id != rechargePlan.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    rechargePlan r = await _context.rechargePlan.FindAsync(rechargePlan.id);
                    rechargePlan.createdAt = r.createdAt;
                    rechargePlan.updatedAt = DateTime.Now;
                    _context.Entry(r).State = EntityState.Detached;
                    _context.Update(rechargePlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rechargePlanExists(rechargePlan.id))
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
            return View(rechargePlan);
        }

        // GET: rechargePlan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rechargePlan = await _context.rechargePlan
                .FirstOrDefaultAsync(m => m.id == id);
            if (rechargePlan == null)
            {
                return NotFound();
            }

            return View(rechargePlan);
        }

        // POST: rechargePlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rechargePlan = await _context.rechargePlan.FindAsync(id);
            if (rechargePlan != null)
            {
                _context.rechargePlan.Remove(rechargePlan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool rechargePlanExists(int id)
        {
            return _context.rechargePlan.Any(e => e.id == id);
        }
    }
}
