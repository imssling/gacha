using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gacha.Models;
using System.Runtime.Intrinsics.X86;
using gacha.ViewModels;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Text.RegularExpressions;

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
            var gachaContext = from admin in _context.admin
                               join role in _context.role
                               on admin.roleId equals role.id
                               select new admin_ViewModel
                               {
                                   account = admin.account,
                                   name = admin.name,
                                   roleId = admin.roleId,
                                   title = role.title,
                                   email = admin.email,
                                   phoneNumber = admin.phoneNumber,
                                   password = admin.password,

                               };
            ViewBag.roleId = new SelectList(_context.role, "id", "title");

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
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("account,name,roleId,email,phoneNumber,password, confirmPassword")] admin_ViewModel admin)
        {
            ViewData["roleId"] = new SelectList(_context.role, "id", "title", admin.roleId);

            //verify if email valid
            var validEmail = admin.email;
            var regexEmail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!regexEmail.IsMatch(validEmail))
            {
                return Json(new { success = false, message = "請輸入有效的電子郵件地址" });
            }

            //verify if taiwan phone number
            var twnumber = admin.phoneNumber;
            var regex = new Regex(@"^09\d{8}$");
            if (!regex.IsMatch(twnumber))
            {
                return Json(new { success = false, message = "請輸入有效的台灣手機號碼，格式為09開頭的十位數字" });
            }

            //verify if account exist
            var adminConfirm = await _context.admin.AnyAsync(a => a.account == admin.account);
            if (adminConfirm)
            {
                return Json(new { success = false, message = "此帳號已存在" });
            }

            //密碼加密
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(admin.password);
            ////把加密和輸入的密碼做比較,一致才存(測試用)
            //bool verify = BCrypt.Net.BCrypt.Verify(admin.password, hashPassword);
            admin.password = hashPassword;
            try
            {
                if (ModelState.IsValid)
                {
                    admin newadmin = new admin()
                    {
                        account = admin.account,
                        roleId = admin.roleId,
                        name = admin.name,
                        email = admin.email,
                        phoneNumber = admin.phoneNumber,
                        password = hashPassword
                    };

                    _context.Add(newadmin);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));

                    // 返回一個 JSON 結果而不是重定向
                    return Json(new { success = true, message = "建立成功" });
                }
                else
                {
                    // 返回一個 JSON 結果，表示數據驗證失敗
                    return Json(new { success = false, message = "建立帳號失敗" });
                }
            }
            catch (Exception ex)
            {

                //Record outstanding actvity and return JSON result
                //可以用紀錄Log.Error(ex)
                return Json(new { success = false, message = "建立帳號有誤", exception = ex.Message });
            }
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
        public async Task<IActionResult> Edit([Bind("account,name,roleId,email,phoneNumber")] admin_ViewModel admin)
        {
            // 移除 ModelState 中 password 的驗證錯誤
            ModelState.Remove("password");
            ModelState.Remove("confirmPassword");

            if (ModelState.IsValid)
            {

                var existingAdmin = await _context.admin.FindAsync(admin.account);
                if (existingAdmin == null)
                {
                    return NotFound();
                }

                //update non password column
                existingAdmin.name = admin.name;
                existingAdmin.roleId = admin.roleId;
                existingAdmin.email = admin.email;
                existingAdmin.phoneNumber = admin.phoneNumber;

                //update password only when user input new password
                if (!string.IsNullOrEmpty(admin.password) && !string.IsNullOrEmpty(admin.confirmPassword))
                {
                    //check password = confirm password
                    if (admin.password == admin.confirmPassword)
                    {
                        existingAdmin.password = BCrypt.Net.BCrypt.HashPassword(admin.password);
                    }
                    else
                    {
                        ModelState.AddModelError("confirmPassword", "密碼和確認密碼不一致");
                        ViewData["roleId"] = new SelectList(_context.role, "id", "title", admin.roleId);

                        return View(admin);
                    }
                    
                }
                try
                {
                    _context.Update(existingAdmin);
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
            var admin = await _context.admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound(new { success = false, message = "未找到該帳號" });
            }

            try
            {
                _context.admin.Remove(admin);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "帳號已成功刪除" });
            }
            catch (Exception ex)
            {
                // 捕捉異常並返回錯誤信息
                return Json(new { success = false, message = "刪除過程中發生錯誤", exception = ex.Message });
            }
        }

        // POST: admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var admin = await _context.admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound(new { success = false, message = "未找到該帳號" });
            }

            try
            {
                _context.admin.Remove(admin);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "帳號已成功刪除" });
            }
            catch (Exception ex)
            {
                // 捕捉異常並返回錯誤信息
                return Json(new { success = false, message = "刪除過程中發生錯誤", exception = ex.Message });
            }
        }

        private bool adminExists(string id)
        {
            return _context.admin.Any(e => e.account == id);
        }
    }
}
