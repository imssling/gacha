using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using szAPI.DTO;
using szAPI.Models;

namespace szAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointListsController : ControllerBase
    {
        private readonly gachaContext _context;

        public PointListsController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/PointLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointList>>> GetPointLists()
        {
            return await _context.PointLists.ToListAsync();
        }

        // 根據使用者ID取得點數紀錄的詳細資訊
        // GET: api/PointLists/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PointDetailDTO>>> GetPointListsByUserId(int userId)
        {
            // 查詢所有符合使用者ID的點數異動紀錄
            var pointLists = await _context.PointLists
                .Where(pl => pl.RechargeList.UserId == userId || pl.Bag.UserId == userId)
                .Include(pl => pl.RechargeList)
                    .ThenInclude(rl => rl.RechargePlan)
                .Include(pl => pl.Bag)
                    .ThenInclude(b => b.GachaProduct)
                        .ThenInclude(gp => gp.Machine)
                .ToListAsync();

            if (pointLists == null || pointLists.Count == 0)
            {
                return NotFound(new { message = "找不到該使用者的任何點數異動紀錄。" });
            }

            // 計算使用者目前的總點數
            var totalPoints = 0;

            // 轉換為 DTO 格式以便返回
            var pointDetailDTOs = pointLists.Select(pl => {
                var pointsChanged = CalculatePointsChanged(pl);
                totalPoints += pointsChanged; // 累計點數變更

                return new PointDetailDTO
                {
                    PointListId = pl.Id,
                    PointsChanged = pointsChanged,
                    TotalPoints = totalPoints,
                    ChangeType = DetermineChangeType(pl),
                    ChangeDate = pl.RechargeListId != null ? DateTime.Now : pl.Bag.Date
                };
            }).ToList();

            return Ok(pointDetailDTOs);

        }
        // 計算點數變更
        private int CalculatePointsChanged(PointList pointList)
        {
            if (pointList.RechargeListId != null)
            {
                // 根據儲值方案計算新增點數
                var rechargePoints = (pointList.RechargeList.RechargePlan.Point)*(pointList.RechargeList.Amount);
                return rechargePoints;
            }
            else if (pointList.BagId != null)
            {
                // 根據商品價格計算減少的點數
                var gachaProduct = pointList.Bag.GachaProduct;
                var machinePrice = gachaProduct.Machine.Price;
                return (-machinePrice);
            }
            else
            {
                return 0;
            }
        }

        // 確定異動的點數是因為會員儲值還是背包操作
        private string DetermineChangeType(PointList pointList)
        {
            if (pointList.RechargeListId != null)
            {
                return "會員儲值";
            }
            else if (pointList.BagId != null)
            {
                return "獲取扭蛋";
            }
            else
            {
                return "unknown";
            }
        }

        // PUT: api/PointLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPointList(int id, PointList pointList)
        {
            if (id != pointList.Id)
            {
                return BadRequest();
            }

            _context.Entry(pointList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PointLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PointList>> PostPointList(PointList pointList)
        {
            _context.PointLists.Add(pointList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointList", new { id = pointList.Id }, pointList);
        }

        // DELETE: api/PointLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePointList(int id)
        {
            var pointList = await _context.PointLists.FindAsync(id);
            if (pointList == null)
            {
                return NotFound();
            }

            _context.PointLists.Remove(pointList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PointListExists(int id)
        {
            return _context.PointLists.Any(e => e.Id == id);
        }
    }
}
