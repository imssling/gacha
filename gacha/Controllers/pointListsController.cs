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
    public class pointListsController : Controller
    {
        private readonly gachaContext _context;

        public pointListsController(gachaContext context)
        {
            _context = context;
        }

        // GET: pointLists
        public async Task<IActionResult> Index()
        {
            var gachaContext = _context.pointList.Include(p => p.achievement).Include(p => p.bag).Include(p => p.rechargeList);
            return View(await gachaContext.ToListAsync());
        }

        // GET: pointLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointList = await _context.pointList
                .Include(p => p.achievement)
                .Include(p => p.bag)
                .Include(p => p.rechargeList)
                .FirstOrDefaultAsync(m => m.id == id);
            if (pointList == null)
            {
                return NotFound();
            }

            return View(pointList);
        }

        // GET: pointLists/Create
        public IActionResult Create()
        {
            ViewData["achievementId"] = new SelectList(_context.achievement, "id", "name");
            ViewData["bagId"] = new SelectList(_context.bag, "id", "gachaStatus");
            ViewData["rechargeListId"] = new SelectList(_context.rechargeList, "id", "paymentMode");
            return View();
        }

        // POST: pointLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,rechargeListId,bagId,achievementId")] pointList pointList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pointList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["achievementId"] = new SelectList(_context.achievement, "id", "name", pointList.achievementId);
            ViewData["bagId"] = new SelectList(_context.bag, "id", "gachaStatus", pointList.bagId);
            ViewData["rechargeListId"] = new SelectList(_context.rechargeList, "id", "paymentMode", pointList.rechargeListId);
            return View(pointList);
        }

        // GET: pointLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointList = await _context.pointList.FindAsync(id);
            if (pointList == null)
            {
                return NotFound();
            }
            ViewData["achievementId"] = new SelectList(_context.achievement, "id", "name", pointList.achievementId);
            ViewData["bagId"] = new SelectList(_context.bag, "id", "gachaStatus", pointList.bagId);
            ViewData["rechargeListId"] = new SelectList(_context.rechargeList, "id", "paymentMode", pointList.rechargeListId);
            return View(pointList);
        }

        // POST: pointLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,rechargeListId,bagId,achievementId")] pointList pointList)
        {
            if (id != pointList.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pointList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pointListExists(pointList.id))
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
            ViewData["achievementId"] = new SelectList(_context.achievement, "id", "name", pointList.achievementId);
            ViewData["bagId"] = new SelectList(_context.bag, "id", "gachaStatus", pointList.bagId);
            ViewData["rechargeListId"] = new SelectList(_context.rechargeList, "id", "paymentMode", pointList.rechargeListId);
            return View(pointList);
        }

        // GET: pointLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointList = await _context.pointList
                .Include(p => p.achievement)
                .Include(p => p.bag)
                .Include(p => p.rechargeList)
                .FirstOrDefaultAsync(m => m.id == id);
            if (pointList == null)
            {
                return NotFound();
            }

            return View(pointList);
        }

        // POST: pointLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pointList = await _context.pointList.FindAsync(id);
            if (pointList != null)
            {
                _context.pointList.Remove(pointList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool pointListExists(int id)
        {
            return _context.pointList.Any(e => e.id == id);
        }
    }
}
