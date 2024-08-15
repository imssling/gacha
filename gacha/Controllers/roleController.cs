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
    public class roleController : Controller
    {
        private readonly gachaContext _context;

        public roleController(gachaContext context)
        {
            _context = context;
        }

        // GET: role
        public async Task<IActionResult> Index()
        {
            return View(await _context.role.ToListAsync());
        }

        // GET: role/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.role
                .FirstOrDefaultAsync(m => m.id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: role/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title")] role role)
        {
            Console.WriteLine(role.id.GetType().Name);  // 輸出 id 的類型，應該是 Int32

            if (ModelState.IsValid)
            {
                _context.Add(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: role/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title")] role role)
        {
            if (id != role.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(role);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!roleExists(role.id))
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
            return View(role);
        }

        // GET: role/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _context.role.FindAsync(id);
            if (role == null)
            {
                return NotFound(new { success = false, message = "未找到該帳號" });
            }

            try
            {
                _context.role.Remove(role);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "帳號已成功刪除" });
            }
            catch (Exception ex)
            {
                // 捕捉異常並返回錯誤信息
                return Json(new { success = false, message = "刪除過程中發生錯誤", exception = ex.Message });
            }
        }

        // POST: role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var role = await _context.role.FindAsync(id);
            if (role == null)
            {
                return NotFound(new { success = false, message = "未找到該帳號" });
            }

            try
            {
                _context.role.Remove(role);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "帳號已成功刪除" });
            }
            catch (Exception ex)
            {
                // 捕捉異常並返回錯誤信息
                return Json(new { success = false, message = "刪除過程中發生錯誤", exception = ex.Message });
            }
        }

        private bool roleExists(int id)
        {
            return _context.role.Any(e => e.id == id);
        }
    }
}
