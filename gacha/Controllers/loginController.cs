using gacha.Models;
using gacha.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(login_ViewModel lvm) //前端輸入的帳號密碼
        {
            var 帳號是否存在 = await _context.admin.FindAsync(lvm.account);

            var 密碼 = await _context.admin.FindAsync(lvm.account); //用帳號找出密碼

            if (ModelState.IsValid)
            {
                if (帳號是否存在 == null)
                {
                    // 丟給畫面判斷錯誤
                    ViewBag.userExist = "1"; //帳號不存在
                    return View(); //欄位的值丟回去,不會被清掉是因為雙向繫節
                }
                var a = BCrypt.Net.BCrypt.Verify(lvm.password, 密碼.password);
                if (!BCrypt.Net.BCrypt.Verify(lvm.password, 密碼.password))
                {
                    ViewBag.userExist = "2";
                    return View();
                }
                //登入成功建立session
                //HttpContext.Session.SetString("login_Success", $"{帳號是否存在.AdminName}");
                HttpContext.Session.SetString("User_Account", $"{帳號是否存在.account}");
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
