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
    public class trackingListsController : Controller
    {
        private readonly gachaContext _context;

        public trackingListsController(gachaContext context)
        {
            _context = context;
        }

        // GET: trackingLists
        public async Task<IActionResult> Index()
        {
            var gachaContext = _context.trackingList.Include(t => t.gachaMachine).Include(t => t.user);
            return View(await gachaContext.ToListAsync());
        }

        // GET: trackingLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackingList = await _context.trackingList
                .Include(t => t.gachaMachine)
                .Include(t => t.user)
                .FirstOrDefaultAsync(m => m.userId == id);
            if (trackingList == null)
            {
                return NotFound();
            }

            return View(trackingList);
        }

        // GET: trackingLists/Create
        public IActionResult Create()
        {
            ViewData["gachaMachineId"] = new SelectList(_context.gachaMachine, "id", "machineName");
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "email");
            return View();
        }

        // POST: trackingLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("userId,gachaMachineId,trackingDate,noteStatus")] trackingList trackingList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trackingList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["gachaMachineId"] = new SelectList(_context.gachaMachine, "id", "machineName", trackingList.gachaMachineId);
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "email", trackingList.userId);
            return View(trackingList);
        }

        // GET: trackingLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackingList = await _context.trackingList.FindAsync(id);
            if (trackingList == null)
            {
                return NotFound();
            }
            ViewData["gachaMachineId"] = new SelectList(_context.gachaMachine, "id", "machineName", trackingList.gachaMachineId);
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "email", trackingList.userId);
            return View(trackingList);
        }

        // POST: trackingLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("userId,gachaMachineId,trackingDate,noteStatus")] trackingList trackingList)
        {
            if (id != trackingList.userId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trackingList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!trackingListExists(trackingList.userId))
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
            ViewData["gachaMachineId"] = new SelectList(_context.gachaMachine, "id", "machineName", trackingList.gachaMachineId);
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "email", trackingList.userId);
            return View(trackingList);
        }

        // GET: trackingLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackingList = await _context.trackingList
                .Include(t => t.gachaMachine)
                .Include(t => t.user)
                .FirstOrDefaultAsync(m => m.userId == id);
            if (trackingList == null)
            {
                return NotFound();
            }

            return View(trackingList);
        }

        // POST: trackingLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trackingList = await _context.trackingList.FindAsync(id);
            if (trackingList != null)
            {
                _context.trackingList.Remove(trackingList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool trackingListExists(int id)
        {
            return _context.trackingList.Any(e => e.userId == id);
        }
    }
}
