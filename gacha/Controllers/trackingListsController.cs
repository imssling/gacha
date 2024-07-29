using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gacha.Models;
using gacha.ViewModels;

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
            var gachaContext =await  _context.trackingList
                .Include(t => t.gachaMachine)
                .Include(t => t.user)
                .Select(t=> new trackingList_ViewModel 
                {
                    UserId = t.userId,
                    UserName = t.user.userName,
                    GachaMachineId = t.gachaMachineId,
                    TrackingDate= t.trackingDate,
                    NoteStatus = t.noteStatus,
                    GachaMachineName=t.gachaMachine.machineName,
                    UserEmail=t.user.email
                }).ToListAsync();
            return View(gachaContext);
        }

        // GET: trackingLists/Details/5
        public async Task<IActionResult> Details(int? id, int? mId)
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

            var user = _context.userInfo.FirstOrDefault(u => u.id == trackingList.userId);
            var gachaMachine = _context.gachaMachine.Where(g => g.id == trackingList.gachaMachineId);

            var x = await (from t in _context.trackingList
                    join u in _context.userInfo
                    on t.userId equals u.id
                    join g in _context.gachaMachine
                    on t.gachaMachineId equals g.id
                    where t.userId == id
                    select new trackingList_ViewModel
                    {
                        UserId = t.userId,
                        GachaMachineId = g.id,
                        TrackingDate = DateTime.Now,
                        NoteStatus = t.noteStatus,
                        GachaMachineName = g.machineName,
                        UserEmail = u.email,
                        UserName = u.userName

                    }).FirstOrDefaultAsync();



            //select userId, gachaMachineId, trackingDate, noteStatus, email, gachaMachine
            //from trackingList t
            //join userInfo u
            //on t.userId = u.id
            //join gachaMachine g
            //on t.gachaMachineId = g.id


            //trackingList_ViewModel trackingListV = new trackingList_ViewModel()
            //{
            //    userId = trackingList.userId,
            //    GachaMachineId = trackingList.gachaMachineId,
            //    TrackingDate = trackingList.trackingDate,
            //    NoteStatus = trackingList.noteStatus,
            //    //GachaMachineName= trackingList.gachaMachine,
            //    //UserEmail = trackingList.UserEmail

            //};

            ViewData["gachaMachineId"] = new SelectList(_context.gachaMachine, "id", "machineName", trackingList.gachaMachineId);
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "id", trackingList.userId);
            return View(x);
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
        public async Task<IActionResult> Edit(int? id, int? mId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackingList = await _context.trackingList.FindAsync(id, mId);
            if (trackingList == null)
            {
                return NotFound();
            }
            ViewData["gachaMachineId"] = new SelectList(_context.gachaMachine, "id", "machineName", trackingList.gachaMachineId);
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "name", trackingList.userId);
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
