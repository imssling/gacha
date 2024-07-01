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
    public class rechargeListsController : Controller
    {
        private readonly gachaContext _context;

        public rechargeListsController(gachaContext context)
        {
            _context = context;
        }

        // GET: rechargeLists
        public async Task<IActionResult> Index()
        {
            var gachaContext = _context.rechargeList.Include(r => r.rechargePlan).Include(r => r.user);
            return View(await gachaContext.ToListAsync());
        }

        // GET: rechargeLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rechargeList = await _context.rechargeList
                .Include(r => r.rechargePlan)
                .Include(r => r.user)
                .FirstOrDefaultAsync(m => m.id == id);
            if (rechargeList == null)
            {
                return NotFound();
            }

            return View(rechargeList);
        }

        // GET: rechargeLists/Create
        public IActionResult Create()
        {
            ViewData["rechargePlanId"] = new SelectList(_context.rechargePlan, "id", "name");
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "email");
            return View();
        }

        // POST: rechargeLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,quantity,amount,paymentMode,rechargePlanId,userId")] rechargeList rechargeList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rechargeList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["rechargePlanId"] = new SelectList(_context.rechargePlan, "id", "name", rechargeList.rechargePlanId);
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "email", rechargeList.userId);
            return View(rechargeList);
        }

        // GET: rechargeLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rechargeList = await _context.rechargeList.FindAsync(id);
            if (rechargeList == null)
            {
                return NotFound();
            }
            ViewData["rechargePlanId"] = new SelectList(_context.rechargePlan, "id", "name", rechargeList.rechargePlanId);
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "email", rechargeList.userId);
            return View(rechargeList);
        }

        // POST: rechargeLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,quantity,amount,paymentMode,rechargePlanId,userId")] rechargeList rechargeList)
        {
            if (id != rechargeList.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rechargeList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rechargeListExists(rechargeList.id))
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
            ViewData["rechargePlanId"] = new SelectList(_context.rechargePlan, "id", "name", rechargeList.rechargePlanId);
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "email", rechargeList.userId);
            return View(rechargeList);
        }

        // GET: rechargeLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rechargeList = await _context.rechargeList
                .Include(r => r.rechargePlan)
                .Include(r => r.user)
                .FirstOrDefaultAsync(m => m.id == id);
            if (rechargeList == null)
            {
                return NotFound();
            }

            return View(rechargeList);
        }

        // POST: rechargeLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rechargeList = await _context.rechargeList.FindAsync(id);
            if (rechargeList != null)
            {
                _context.rechargeList.Remove(rechargeList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool rechargeListExists(int id)
        {
            return _context.rechargeList.Any(e => e.id == id);
        }
    }
}
