using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gacha.Models;
using gacha.ViewModel;
using System.Net;

namespace gacha.Controllers
{
    public class userInfoesController : Controller
    {
        private readonly gachaContext _context;

        public userInfoesController(gachaContext context)
        {
            _context = context;
            
        }

        // GET: userInfoes
        public async Task<IActionResult> Index()
        {
           
            return View(_context.userInfo);
        }

        // GET: userInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.userInfo
                .FirstOrDefaultAsync(m => m.id == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // GET: userInfoes/Create
        public IActionResult Create()
        {
            //增加userInfo Gender的select選項
            ViewBag.gender = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "女", Text = "女" },
                new SelectListItem { Value = "男", Text = "男" }
            }, "Value", "Text");
            return View();
        }

        // POST: userInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userName,phoneNumber,email,address,gender")] userInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            //增加userInfo Gender的select選項
            ViewBag.gender = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "女", Text = "女" },
                new SelectListItem { Value = "男", Text = "男" }
            });
            return View(userInfo);
        }

        // GET: userInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.userInfo.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            //增加userInfo Gender的select選項
            ViewBag.gender = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "女", Text = "女" },
                new SelectListItem { Value = "男", Text = "男" }
            }, "Value", "Text");
        
            return View(userInfo);
        }

        // POST: userInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,userName,phoneNumber,email,address,gender")] userInfo userInfo)
        {
            if (id != userInfo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    userInfo.address = userInfo.address.Replace("_", "");
                    _context.Update(userInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userInfoExists(userInfo.id))
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
            //增加userInfo Gender的select選項
            ViewBag.gender = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "女", Text = "女" },
                new SelectListItem { Value = "男", Text = "男" }
            });

            return View(userInfo);
        }

        // GET: userInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var userInfo = await _context.userInfo.FindAsync(id);
            if (userInfo != null)
            {
                _context.userInfo.Remove(userInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: userInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userInfo = await _context.userInfo.FindAsync(id);
            if (userInfo != null)
            {
                _context.userInfo.Remove(userInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userInfoExists(int id)
        {
            return _context.userInfo.Any(e => e.id == id);
        }
    }
}
