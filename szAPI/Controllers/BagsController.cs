using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using szAPI.DTO;
using szAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace szAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagsController : ControllerBase
    {
        private readonly gachaContext _context;

        public BagsController(gachaContext context)
        {
            _context = context;
        }

        //查詢所有的背包資料
        // GET: api/Bags
        [HttpGet]
        public async Task<IEnumerable<BagDTO>> GetBags() //藉由使用者ID去列出所有背包資料
        {
            return _context.Bags
                .Include(b => b.GachaProduct)
                .ThenInclude(gp => gp.Machine)
                .ThenInclude(gm => gm.Theme)
                .OrderBy(b => b.UserId)
                .Select(Bags => new BagDTO
            {
                id = Bags.Id,
                gachaProductId = Bags.GachaProductId,
                userId = Bags.UserId,
                productName = Bags.GachaProduct.ProductName,
                machineName = Bags.GachaProduct.Machine.MachineName,
                themeName = Bags.GachaProduct.Machine.Theme.ThemeName,
                gachaStatus = Bags.GachaStatus,
                date = Bags.Date,
            });
        }

        //查詢特定會員所有背包的資料
        // GET: api/Bags/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<BagDTO>>> GetBagsByUserId(int userId)
        {
            var bags = await _context.Bags
                .Include(b => b.GachaProduct)
                .ThenInclude(gp => gp.Machine)
                .ThenInclude(gm => gm.Theme)
                .Where(b => b.UserId == userId)
                .Select(b => new BagDTO
                {
                    id = b.Id,
                    gachaProductId = b.GachaProductId,
                    userId = b.UserId,
                    productName = b.GachaProduct.ProductName,
                    machineName = b.GachaProduct.Machine.MachineName,
                    themeName = b.GachaProduct.Machine.Theme.ThemeName,
                    gachaStatus = b.GachaStatus,
                    date = b.Date,
                })
                .ToListAsync();

            if (bags == null)
            {
                return null;
            }

            return bags;
        }

        // 修改特定會員的所有背包資料
        // PUT: api/Bags/user/{userId}/{id}
        [HttpPut("user/{userId}/{id}")]
        public async Task<string> PutBag(int userId, int id, BagDTO bagDTO)
        {
            if (id != bagDTO.id || userId != bagDTO.userId)
            {
                return "會員資料錯誤!";
            }

            var existingBag = await _context.Bags
                .Include(b => b.GachaProduct)
                    .ThenInclude(gp => gp.Machine)
                        .ThenInclude(gm => gm.Theme)
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (existingBag == null)
            {
                return "找無該筆會員的背包資料!";
            }

            // 更新背包中的資料
            existingBag.GachaProductId = bagDTO.gachaProductId;
            existingBag.GachaProduct.ProductName = bagDTO.productName; 
            existingBag.GachaProduct.Machine.MachineName = bagDTO.machineName; 
            existingBag.GachaProduct.Machine.Theme.ThemeName = bagDTO.themeName; 
            existingBag.GachaStatus = bagDTO.gachaStatus;
            existingBag.Date = bagDTO.date;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagExists(id))
                {
                    return "找無該筆會員的背包資料!";
                }
                else
                {
                    throw;
                }
            }

            return "成功修改該筆會員的背包資料!";
        }

        private bool BagExists(int id)
        {
            throw new NotImplementedException();
        }

        // 新增會員的背包資料
        // POST: api/Bags/user/{userId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("user/{userId}")]
        public async Task<string> PostBag(int userId, BagDTO bagDTO)
        {
            var bag = new Bag
            {
                GachaProductId = bagDTO.gachaProductId,
                UserId = userId,  // 使用傳遞進來的userId
                GachaStatus = bagDTO.gachaStatus,
                Date = bagDTO.date
            };
            _context.Bags.Add(bag);
            await _context.SaveChangesAsync();

            return $"成功新增會員背包資料，該會員編號為:{userId}";
        }

        //刪除指定會員裡的特定背包資料
        // DELETE: api/Bags/user/{userId}/bag/{bagId}
        [HttpDelete("user/{userId}/bag/{bagId}")]
        public async Task<string> DeleteBag(int userId, int bagId)
        {
            var bag = await _context.Bags
                .Where(b => b.UserId == userId && b.Id == bagId)
                .FirstOrDefaultAsync();

            if (bag == null)
            {
                return "找不到要刪除的會員背包資料!";
            }

            try
            {
                _context.Bags.Remove(bag);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return "刪除會員背包資料失敗!";
            }

            return "刪除會員背包資料成功!";
        }
    }
}
