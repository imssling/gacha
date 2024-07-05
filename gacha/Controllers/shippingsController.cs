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
    public class shippingsController : Controller
    {
        private readonly gachaContext _context;

        public shippingsController(gachaContext context)
        {
            _context = context;
        }

        //增加一個 Api Endpoint
        [HttpGet]
        public JsonResult GetShippingAddresses(int userId)
        {
            var addresses = _context.userInfo
                .Where(u => u.id == userId)
                .Select(u => new { u.address })
                .ToList();
            return Json(addresses);
        }


        // GET: shippings
        public async Task<IActionResult> Index()
        {
            var gachaContext = _context.shipping.Include(s => s.user);
            return View(await gachaContext.ToListAsync());
        }

        // GET: shippings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = await _context.shipping
                .Include(s => s.user)
                .FirstOrDefaultAsync(m => m.id == id);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // GET: shippings/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "id");
            ViewData["shippingAddress"] = new SelectList(_context.userInfo, "id", "address");

            //增加shipping status的select選項
            ViewBag.shippingStatus = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "待處理", Text = "待處理" },
                new SelectListItem { Value = "已發貨", Text = "已發貨" },
                new SelectListItem { Value = "已取消", Text = "已取消" },
                new SelectListItem { Value = "已完成", Text = "已完成" }
            },"Value", "Text");

            //增加shipping Method的select選項
            ViewBag.shippingMethod = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "宅配", Text = "宅配" },
                new SelectListItem { Value = "超商-711", Text = "超商-711" }
            }, "Value", "Text");

            // 增加shipping fee的select選項(設定自動選擇 shippingfee based on shipping Method)
            ViewBag.shippingFee = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "100", Text = "$100" },
                new SelectListItem { Value = "70", Text = "$70" }
            }, "Value", "Text");


            return View();
        }

        // POST: shippings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userId,shippingDate,shippingStatus,shippingAddress,contactPhone,shippingMethod,shippingFee")] shipping shipping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "id", shipping.userId);

            //增加shipping status的select選項
            ViewBag.shippingStatus = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "待處理", Text = "待處理" },
                new SelectListItem { Value = "已發貨", Text = "已發貨" },
                new SelectListItem { Value = "已取消", Text = "已取消" },
                new SelectListItem { Value = "已完成", Text = "已完成" }
            }, "Value", "Text");
            //增加shipping Method的select選項
            ViewBag.shippingMethod = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "宅配", Text = "宅配" },
                new SelectListItem { Value = "超商-711", Text = "超商-711" }
            }, "Value", "Text");

            // 增加shipping fee的select選項(設定自動選擇 shippingfee based on shipping Method)
            ViewBag.shippingFee = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "100", Text = "$100" },
                new SelectListItem { Value = "70", Text = "$70" }
            }, "Value", "Text");

            return View(shipping);
        }

        // GET: shippings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = await _context.shipping.FindAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "id", shipping.userId);

            //增加shipping status的select選項
            ViewBag.shippingStatus = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "待處理", Text = "待處理" },
                new SelectListItem { Value = "已發貨", Text = "已發貨" },
                new SelectListItem { Value = "已取消", Text = "已取消" },
                new SelectListItem { Value = "已完成", Text = "已完成" }
            }, "Value", "Text");
            //增加shipping fee的select選項
            ViewBag.shippingMethod = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "宅配", Text = "宅配" },
                new SelectListItem { Value = "超商-711", Text = "超商-711" }
            }, "Value", "Text");

            return View(shipping);
        }

        // POST: shippings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,userId,shippingDate,shippingStatus,shippingAddress,contactPhone,shippingMethod,shippingFee")] shipping shipping)
        {
            if (id != shipping.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!shippingExists(shipping.id))
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
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "email", shipping.userId);

            //增加shipping status的select選項
            ViewBag.shippingStatus = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "待處理", Text = "待處理" },
                new SelectListItem { Value = "已發貨", Text = "已發貨" },
                new SelectListItem { Value = "已取消", Text = "已取消" },
                new SelectListItem { Value = "已完成", Text = "已完成" }
            });
            //增加shipping fee的select選項
            ViewBag.shippingMethod = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "宅配", Text = "宅配" },
                new SelectListItem { Value = "超商-711", Text = "超商-711" }
            });
            return View(shipping);
        }

        // GET: shippings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = await _context.shipping
                .Include(s => s.user)
                .FirstOrDefaultAsync(m => m.id == id);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // POST: shippings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipping = await _context.shipping.FindAsync(id);
            if (shipping != null)
            {
                _context.shipping.Remove(shipping);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool shippingExists(int id)
        {
            return _context.shipping.Any(e => e.id == id);
        }
    }
}
