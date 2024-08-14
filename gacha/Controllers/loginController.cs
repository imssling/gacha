using gacha.Models;
using gacha.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gacha.Controllers
{
    public class loginController : Controller
    {
        private readonly gachaContext _context;
        public loginController(gachaContext context)
        {
            _context = context;
        }
        public IActionResult login()
        {
            ViewBag.userExist = new { errorCode = 0 , errorMessage = "hi" };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(login_ViewModel lvm) //前端輸入的帳號密碼
        {
            var admin = await _context.admin.FindAsync(lvm.account); //帳號是否存在

            if (ModelState.IsValid)
            {
                if (admin == null)
                {
                    // 丟給畫面判斷錯誤
                    ViewBag.userExist = new { errorCode = 1 , errorMessage = "帳號不存在" } ; 
                    return View(); //欄位的值丟回去,不會被清掉是因為雙向繫節
                }

                //確認資料庫的密碼和輸入的密碼是否相同
                if (!BCrypt.Net.BCrypt.Verify(lvm.password, admin.password))
                {
                    ViewBag.userExist = new { errorCode = 2, errorMessage = "密碼錯誤" }; 
                    return View();
                }

                //登入成功建立session 存名字
                HttpContext.Session.SetString("Login_Name", $"{admin.name}");
                //登入成功建立session 存帳號
                HttpContext.Session.SetString("Login_Account", $"{admin.account}");
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Logout()
        {
            // 清除所有 Session 數據
            HttpContext.Session.Clear();          
            return RedirectToAction("login", "login");
        }

    }
}
