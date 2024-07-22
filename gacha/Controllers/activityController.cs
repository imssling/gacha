using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gacha.Models;
using gacha.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics;

namespace gacha.Controllers
{
    public class activityController : Controller
    {
        private readonly gachaContext _context;

        public activityController(gachaContext context)
        {
            _context = context;
        }

        // GET: activity
        public async Task<IActionResult> Index()
        {
            //var gachaContext = _context.activity.Include(a => a.activityType);

            var gachaContext = from activity in _context.activity
                               join activityType in _context.activityType
                               on activity.activityTypeId equals activityType.id
                               select new activity_ViewModel
                               {
                                   id = activity.id,
                                   title = activity.title,
                                   description = activity.description,
                                   status = activity.status,
                                   createdAt = activity.createdAt,
                                   activityStart = activity.activityStart,
                                   activityEnd = activity.activityEnd,
                                   activityTypeId = activity.activityTypeId,
                                   activityTypeName = activityType.name
                               };
            ViewBag.activityTypeId = new SelectList(_context.activityType, "id", "name");
            return View(await gachaContext.ToListAsync());
            //.Select(activityV => new activity_ViewModel 
            //{
            //    id= activityV.id,
            //    title = activityV.title,
            //    description = activityV.description,
            //    status = activityV.status,
            //    activityTypeId = activityV.activityTypeId,
            //    createdAt = activityV.createdAt,
            //    activityStart = activityV.activityStart,
            //    activityEnd = activityV.activityEnd

            //});

        }

        // GET: activity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.activity
                .Include(a => a.activityType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: activity/Create
        public IActionResult Create()
        {
            ViewData["activityTypeId"] = new SelectList(_context.activityType, "id", "name");
            return PartialView();
        }

        // POST: activity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,description,status,activityTypeId, activityTypeName,createdAt,activityStart,activityEnd")] activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["activityTypeId"] = new SelectList(_context.activityType, "id", "name", activity.activityTypeId);
            return View(activity);
        }

        // GET: activity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.activity.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            var activityType = await _context.activityType.FindAsync(activity.activityTypeId);
            if (activityType == null)
            {
                return NotFound();
            }

            ViewData["activityTypeId"] = new SelectList(_context.activityType, "id", "name", activity.activityTypeId);
            var activityVM = new activity_ViewModel
            {
                id = activity.id,
                title = activity.title,
                description = activity.description,
                status = activity.status,
                createdAt = activity.createdAt,
                activityStart = activity.activityStart,
                activityEnd = activity.activityEnd,
                activityTypeId = activity.activityTypeId,
                activityTypeName = activityType.name
            };

            return View(activityVM);
        }

        // POST: activity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,description,status,activityTypeId, activityTypeName,createdAt,activityStart,activityEnd")] activity activity)
        {
            if (id != activity.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!activityExists(activity.id))
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
            ViewData["activityTypeId"] = new SelectList(_context.activityType, "id", "name", activity.activityTypeId);
            return View(activity);
        }

        // GET: activity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.activity
                .Include(a => a.activityType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.activity.FindAsync(id);
            if (activity != null)
            {
                _context.activity.Remove(activity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool activityExists(int id)
        {
            return _context.activity.Any(e => e.id == id);
        }
    }
}
