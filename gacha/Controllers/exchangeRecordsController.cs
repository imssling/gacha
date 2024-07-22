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
    public class exchangeRecordsController : Controller
    {
        private readonly gachaContext _context;

        public exchangeRecordsController(gachaContext context)
        {
            _context = context;
        }

        // GET: exchangeRecords
        public async Task<IActionResult> Index()
        {
            //var gachaContext = _context.exchangeRecord.Include(e => e.id).Include(e => e.userIdFrom).Include(e => e.userIdTo).Include(e => e.gachaIdFrom).Include(e=>e.gachaIdTo).Include(e=>e.exchangeDate)
            //    .Select(e => new exchangeRecord_ViewModel
            //    {
            //        id = e.id,
            //        UserIdFrom = e.userIdFrom,
            //        UserIdTo = e.userIdTo,
            //        GachaIdFrom = e.gachaIdFrom,
            //        GachaIdTo = e.gachaIdTo,
            //        ExchangeDate =  e.exchangeDate 

            //    });
            //return View(await gachaContext.ToListAsync());



            var gachaContext = _context.exchangeRecord
                .Select(e => new exchangeRecord_ViewModel
                {
                    id = e.id,
                    UserName = e.userIdFromNavigation.userName,
                    UserNameTo = e.userIdToNavigation.userName,
                    GachaNameFrom = e.gachaIdFromNavigation.productName,
                    GachaNameTo = e.gachaIdToNavigation.productName,
                    ExchangeDate = e.exchangeDate

                });


            return View(gachaContext);
         
        }

        // GET: exchangeRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var exchangeRecord = await _context.exchangeRecord
            //    .Include(e => e.gachaIdFromNavigation)
            //    .Include(e => e.gachaIdToNavigation)
            //    .Include(e => e.userIdFromNavigation)
            //    .Include(e => e.userIdToNavigation)
            //    .FirstOrDefaultAsync(m => m.id == id);
            //if (exchangeRecord == null)
            //{
            //    return NotFound();
            //}

            var exchangeRecord = await _context.exchangeRecord
                .Include(e => e.gachaIdFromNavigation)
                .Include(e => e.gachaIdToNavigation)
                .Include(e => e.userIdFromNavigation)
                .Include(e => e.userIdToNavigation)
                .FirstOrDefaultAsync(m => m.id == id);
            if (exchangeRecord == null)
            {
                return NotFound();
            }

            exchangeRecord_ViewModel exchangeRecView = new exchangeRecord_ViewModel()
            {
                id = exchangeRecord.id,
                UserName = exchangeRecord.userIdFromNavigation.userName,
                UserNameTo = exchangeRecord.userIdToNavigation.userName,
                GachaNameFrom = exchangeRecord.gachaIdFromNavigation.productName,
                GachaNameTo = exchangeRecord.gachaIdToNavigation.productName,
                ExchangeDate = exchangeRecord.exchangeDate

            };

            return View(exchangeRecView);
        }

        // GET: exchangeRecords/Create
        public IActionResult Create()
        {
            ViewData["gachaIdFrom"] = new SelectList(_context.gachaProduct, "id", "productName");
            ViewData["gachaIdTo"] = new SelectList(_context.gachaProduct, "id", "productName");
            ViewData["userIdFrom"] = new SelectList(_context.userInfo, "id", "email");
            ViewData["userIdTo"] = new SelectList(_context.userInfo, "id", "email");
            return View();
        }

        // POST: exchangeRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userIdFrom,userIdTo,gachaIdFrom,gachaIdTo,exchangeDate")] exchangeRecord exchangeRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exchangeRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["gachaIdFrom"] = new SelectList(_context.gachaProduct, "id", "productName", exchangeRecord.gachaIdFrom);
            ViewData["gachaIdTo"] = new SelectList(_context.gachaProduct, "id", "productName", exchangeRecord.gachaIdTo);
            ViewData["userIdFrom"] = new SelectList(_context.userInfo, "id", "email", exchangeRecord.userIdFrom);
            ViewData["userIdTo"] = new SelectList(_context.userInfo, "id", "email", exchangeRecord.userIdTo);
            return View(exchangeRecord);
        }

        // GET: exchangeRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRecord = await _context.exchangeRecord.FindAsync(id);
            if (exchangeRecord == null)
            {
                return NotFound();
            }

            ViewData["gachaIdFrom"] = new SelectList(_context.gachaProduct, "id", "productName", exchangeRecord.gachaIdFrom);
            ViewData["gachaIdTo"] = new SelectList(_context.gachaProduct, "id", "productName", exchangeRecord.gachaIdTo);
            ViewData["userIdFrom"] = new SelectList(_context.userInfo, "id", "email", exchangeRecord.userIdFrom);
            ViewData["userIdTo"] = new SelectList(_context.userInfo, "id", "email", exchangeRecord.userIdTo);
            return View(exchangeRecord);
        }

        // POST: exchangeRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,userIdFrom,userIdTo,gachaIdFrom,gachaIdTo,exchangeDate")] exchangeRecord exchangeRecord)
        {
            if (id != exchangeRecord.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exchangeRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!exchangeRecordExists(exchangeRecord.id))
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
            ViewData["gachaIdFrom"] = new SelectList(_context.gachaProduct, "id", "productName", exchangeRecord.gachaIdFrom);
            ViewData["gachaIdTo"] = new SelectList(_context.gachaProduct, "id", "productName", exchangeRecord.gachaIdTo);
            ViewData["userIdFrom"] = new SelectList(_context.userInfo, "id", "email", exchangeRecord.userIdFrom);
            ViewData["userIdTo"] = new SelectList(_context.userInfo, "id", "email", exchangeRecord.userIdTo);
            return View(exchangeRecord);
        }

        // GET: exchangeRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRecord = await _context.exchangeRecord
                .Include(e => e.gachaIdFromNavigation)
                .Include(e => e.gachaIdToNavigation)
                .Include(e => e.userIdFromNavigation)
                .Include(e => e.userIdToNavigation)
                .FirstOrDefaultAsync(m => m.id == id);
            if (exchangeRecord == null)
            {
                return NotFound();
            }

            return View(exchangeRecord);
        }

        // POST: exchangeRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exchangeRecord = await _context.exchangeRecord.FindAsync(id);
            if (exchangeRecord != null)
            {
                _context.exchangeRecord.Remove(exchangeRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool exchangeRecordExists(int id)
        {
            return _context.exchangeRecord.Any(e => e.id == id);
        }
    }
}
