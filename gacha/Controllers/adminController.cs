﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gacha.Models;
using System.Runtime.Intrinsics.X86;

namespace gacha.Controllers
{
    public class adminController : Controller
    {
        private readonly gachaContext _context;

        public adminController(gachaContext context)
        {
            _context = context;
        }

        // GET: admin
        public async Task<IActionResult> Index()
        {
            var gachaContext = _context.admin.Include(a => a.role);
            return View(await gachaContext.ToListAsync());
        }

        // GET: admin/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.admin
                .Include(a => a.role)
                .FirstOrDefaultAsync(m => m.account == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: admin/Create
        public IActionResult Create()
        {
            ViewData["roleId"] = new SelectList(_context.role, "id", "title");
            return View();
        }

        // POST: admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("account,name,roleId,email,phoneNumber,password")] admin admin)
        {
            //密碼加密
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(admin.password);

            //把加密和輸入的密碼做比較,一致才存(測試用)
            bool verify = BCrypt.Net.BCrypt.Verify(admin.password, hashPassword);
            admin.password = hashPassword;

            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["roleId"] = new SelectList(_context.role, "id", "title", admin.roleId);
            return View(admin);
        }

        // GET: admin/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            ViewData["roleId"] = new SelectList(_context.role, "id", "title", admin.roleId);
            return View(admin);
        }

        // POST: admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("account,name,roleId,email,phoneNumber,password")] admin admin)
        {
            if (id != admin.account)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!adminExists(admin.account))
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
            ViewData["roleId"] = new SelectList(_context.role, "id", "title", admin.roleId);
            return View(admin);
        }

        // GET: admin/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.admin
                .Include(a => a.role)
                .FirstOrDefaultAsync(m => m.account == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var admin = await _context.admin.FindAsync(id);
            if (admin != null)
            {
                _context.admin.Remove(admin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool adminExists(string id)
        {
            return _context.admin.Any(e => e.account == id);
        }
    }
}
