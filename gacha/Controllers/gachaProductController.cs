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
    public class gachaProductController : Controller
    {
        private readonly gachaContext _context;

        public gachaProductController(gachaContext context)
        {
            _context = context;
        }

        // GET: gachaProduct
        public async Task<IActionResult> Index()
        {
            var gachaContext = _context.gachaProduct.Include(g => g.machine);
            return View(await gachaContext.ToListAsync());
        }

        // GET: gachaProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaProduct = await _context.gachaProduct
                .Include(g => g.machine)
                .FirstOrDefaultAsync(m => m.id == id);
            if (gachaProduct == null)
            {
                return NotFound();
            }

            return View(gachaProduct);
        }

        // GET: gachaProduct/Create
        public IActionResult Create()
        {
            ViewData["machineId"] = new SelectList(_context.gachaMachine, "id", "machineName");
            return View();
        }

        // POST: gachaProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,machineId,productName,stock,productPictureName,createTime")] gachaProduct gachaProduct)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files["productPictureName"] != null)
                {
                    // 取得照片欄位名稱
                    var pictureFile = Request.Form.Files["productPictureName"];

                    // 新增存圖檔路徑
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
                    // 確保目標目錄存在
                    if (!Directory.Exists(uploadsFolder))
                    {
                        // 如果路徑不在則創建
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // 生成唯一的文件名以避免重名
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + pictureFile.FileName;

                    // 目標文件的完整路徑
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // 將文件保存到指定路徑(合併檔名和路徑)
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await pictureFile.CopyToAsync(fileStream);
                    }

                    // 更新圖片路徑
                    gachaProduct.productPictureName = uniqueFileName;
                }

                _context.Add(gachaProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["machineId"] = new SelectList(_context.gachaMachine, "id", "machineName", gachaProduct.machineId);
            return View(gachaProduct);
        }

        // GET: gachaProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaProduct = await _context.gachaProduct.FindAsync(id);
            if (gachaProduct == null)
            {
                return NotFound();
            }
            ViewData["machineId"] = new SelectList(_context.gachaMachine, "id", "machineName", gachaProduct.machineId);
            return View(gachaProduct);
        }

        // POST: gachaProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,machineId,productName,stock,productPictureName")] gachaProduct gachaProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // 取出原先所有資料
                    gachaProduct p = await _context.gachaProduct.FindAsync(gachaProduct.id);

                    // 設置 createTime 為原來的值
                    gachaProduct.createTime = p.createTime;

                    // 判斷是否有上傳檔案
                    if (Request.Form.Files["productPictureName"] != null)
                    {
                        // 取得照片欄位名稱
                        var pictureFile = Request.Form.Files["productPictureName"];

                        // 新增存圖檔路徑
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
                        // 確保目標目錄存在
                        if (!Directory.Exists(uploadsFolder))
                        {
                            // 如果路徑不在則創建
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // 生成唯一的文件名以避免重名
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + pictureFile.FileName;

                        // 目標文件的完整路徑
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // 將文件保存到指定路徑(合併檔名和路徑)
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await pictureFile.CopyToAsync(fileStream);
                        }


                        // 更新圖片路徑
                        gachaProduct.productPictureName = uniqueFileName;
                    }
                    else
                    {
                        // 放入原先資料
                        gachaProduct.productPictureName = p.productPictureName;
                    }
                        // 解除追蹤
                        _context.Entry(p).State = EntityState.Detached;
                        _context.Update(gachaProduct);
                        await _context.SaveChangesAsync();
                        // 刪除舊圖片文件（如果有）
                        // 判斷是否原有圖片
                        if (!string.IsNullOrEmpty(p.productPictureName))
                        {
                            // 取得當前目錄,圖片存放路徑, 去掉路徑開頭的 / 符號，以防止路徑不正確
                            var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", p.productPictureName.TrimStart('/'));
                            // 檢查舊圖片文件是否存在
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                // 存在則刪除照片
                                System.IO.File.Delete(oldFilePath);
                            }
                        }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!gachaProductExists(gachaProduct.id))
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
            ViewData["machineId"] = new SelectList(_context.gachaMachine, "id", "machineName", gachaProduct.machineId);
            return View(gachaProduct);
        }

        // GET: gachaProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaProduct = await _context.gachaProduct
                .Include(g => g.machine)
                .FirstOrDefaultAsync(m => m.id == id);
            if (gachaProduct == null)
            {
                return NotFound();
            }

            return View(gachaProduct);
        }

        // POST: gachaProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gachaProduct = await _context.gachaProduct.FindAsync(id);
            if (gachaProduct != null)
            {
                _context.gachaProduct.Remove(gachaProduct);
            }

            // 刪除舊圖片文件（如果有）
            // 判斷是否原有圖片
            if (!string.IsNullOrEmpty(gachaProduct.productPictureName))
            {
                // 取得當前目錄,圖片存放路徑, 去掉路徑開頭的 / 符號，以防止路徑不正確
                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", gachaProduct.productPictureName.TrimStart('/'));
                // 檢查舊圖片文件是否存在
                if (System.IO.File.Exists(oldFilePath))
                {
                    // 存在則刪除照片
                    System.IO.File.Delete(oldFilePath);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool gachaProductExists(int id)
        {
            return _context.gachaProduct.Any(e => e.id == id);
        }
    }
}
