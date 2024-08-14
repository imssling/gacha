using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gacha.Models;
using Microsoft.IdentityModel.Tokens;

namespace gacha.Controllers
{
    public class gachaMachineController : Controller
    {
        private readonly gachaContext _context;

        public gachaMachineController(gachaContext context)
        {
            _context = context;
        }

        // GET: gachaMachine
        public async Task<IActionResult> Index()
        {
            ViewData["themeId"] = new SelectList(_context.gachaTheme, "id", "themeName");
            var gachaContext = _context.gachaMachine.Include(g => g.theme);
            return View(await gachaContext.ToListAsync());
        }

        // GET: gachaMachine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaMachine = await _context.gachaMachine
                .Include(g => g.theme)
                .FirstOrDefaultAsync(m => m.id == id);
            if (gachaMachine == null)
            {
                return NotFound();
            }

            return View(gachaMachine);
        }

        // GET: gachaMachine/Create
        public IActionResult Create()
        {
            ViewData["themeId"] = new SelectList(_context.gachaTheme, "id", "themeName");
            return View();
        }

        // POST: gachaMachine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,themeId,machineName,machineDescription,machinePictureName,createTime,price")] gachaMachine gachaMachine)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files["machinePictureName"] != null)
                {
                    // 取得照片欄位名稱
                    var pictureFile = Request.Form.Files["machinePictureName"];

                    // 新增存圖檔路徑
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "C:\\資展\\結業專題\\0812\\gacha\\wwwroot\\imgs", "C:\\資展\\結業專題\\gacha_v6\\gacha\\wwwroot\\img");
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
                    gachaMachine.machinePictureName = uniqueFileName;
                }

                _context.Add(gachaMachine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["themeId"] = new SelectList(_context.gachaTheme, "id", "themeName", gachaMachine.themeId);
            return View(gachaMachine);
        }

        // GET: gachaMachine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaMachine = await _context.gachaMachine.FindAsync(id);
            if (gachaMachine == null)
            {
                return NotFound();
            }
            ViewData["themeId"] = new SelectList(_context.gachaTheme, "id", "themeName", gachaMachine.themeId);
            return View(gachaMachine);
        }

        // POST: gachaMachine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("id,themeId,machineName,machineDescription,machinePictureName,price")] gachaMachine gachaMachine)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    // 取出原先所有資料
                    gachaMachine p = await _context.gachaMachine.FindAsync(gachaMachine.id);


                    // 判斷是否有上傳檔案
                    if (Request.Form.Files["machinePictureName"] != null)
                    {
                            // 取得照片欄位名稱
                            var pictureFile = Request.Form.Files["machinePictureName"];

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
                            gachaMachine.machinePictureName = uniqueFileName;
                            gachaMachine.createTime = DateTime.Now;
                    }
                    else
                    {
                            // 放入原先資料
                            gachaMachine.machinePictureName = p.machinePictureName;
                            gachaMachine.createTime = DateTime.Now;



                    }
                    // 解除追蹤
                    _context.Entry(p).State = EntityState.Detached;
                            _context.Update(gachaMachine);
                            await _context.SaveChangesAsync();

                            // 刪除舊圖片文件（如果有）
                            // 判斷是否原有圖片
                            if (!string.IsNullOrEmpty(p.machinePictureName))
                            {
                                // 取得當前目錄,圖片存放路徑, 去掉路徑開頭的 / 符號，以防止路徑不正確
                                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", p.machinePictureName.TrimStart('/'));
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
                    if (!gachaMachineExists(gachaMachine.id))
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
            ViewData["themeId"] = new SelectList(_context.gachaTheme, "id", "themeName", gachaMachine.themeId);
            return View(gachaMachine);
        }

        // GET: gachaMachine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaMachine = await _context.gachaMachine
                .Include(g => g.theme)
                .FirstOrDefaultAsync(m => m.id == id);
            if (gachaMachine == null)
            {
                return NotFound();
            }

            return View(gachaMachine);
        }

        // POST: gachaMachine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gachaMachine = await _context.gachaMachine.FindAsync(id);
            if (gachaMachine != null)
            {
                _context.gachaMachine.Remove(gachaMachine);
            }

            await _context.SaveChangesAsync();

            // 刪除舊圖片文件（如果有）
            // 判斷是否原有圖片
            if (!string.IsNullOrEmpty(gachaMachine.machinePictureName))
            {
                // 取得當前目錄,圖片存放路徑, 去掉路徑開頭的 / 符號，以防止路徑不正確
                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", gachaMachine.machinePictureName.TrimStart('/'));
                // 檢查舊圖片文件是否存在
                if (System.IO.File.Exists(oldFilePath))
                {
                    // 存在則刪除照片
                    System.IO.File.Delete(oldFilePath);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool gachaMachineExists(int id)
        {
            return _context.gachaMachine.Any(e => e.id == id);
        }
    }
}
