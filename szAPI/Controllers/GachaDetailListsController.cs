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
    public class GachaDetailListsController : ControllerBase
    {
        private readonly gachaContext _context;

        public GachaDetailListsController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/GachaDetailLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GachaDetailList>>> GetGachaDetailLists()
        {
            return await _context.GachaDetailLists.ToListAsync();
        }

        // GET: api/GachaDetailLists/user/{userId}
        //現在三個ID都有值，等修改過後再檢查一下
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GachaDetailListDTO>>> GetGachaDetailListByUserId(int userId)
        {
            var gachaDetailList = await _context.GachaDetailLists
                .Where(gdl => gdl.Bag.UserId == userId || gdl.ExchangeRecord.UserIdFrom == userId || gdl.UploadRecord.Bag.UserId == userId)
                .Include(gdl => gdl.ExchangeRecord)
                .Include (gdl => gdl.UploadRecord)
                .Include(gdl => gdl.Bag)
                .ToListAsync();

            if (gachaDetailList == null || gachaDetailList.Count == 0)
            {
                return NotFound(new { message = "找不到該使用者的任何扭蛋異動紀錄。" });
            }

            // 轉換為 DTO 格式以便返回
            var gachaDetailListDTO = gachaDetailList.Select(gdl => {

                return new GachaDetailListDTO
                {
                    id = gdl.Id,
                    gachaProductName = gdl.Bag.GachaProduct.ProductName ?? "未知商品",
                    status = ConfirmStatus(gdl),
                    //quantity = 1, //數量怎寫
                    updateTime = ConfirmUpdateTime(gdl),
                };
            }).ToList();

            return Ok(gachaDetailListDTO);
        }

        private string ConfirmStatus(GachaDetailList gachaDetailList)
        {
            if (gachaDetailList.BagId != null)
            {
                return "新獲取";
            }
            else if (gachaDetailList.ExchangeRecordId != null)
            {
                return "已交換"; //這裡邏輯
            }
            else if (gachaDetailList.UploadRecordId != null)
            {
                return "已上架";
            }
            //還要新增出貨ID
            else
            {
                return "未知";
            }       
        }

        private DateTime ConfirmUpdateTime(GachaDetailList gachaDetailList)
        {
            if (gachaDetailList.BagId != null)
            {
                return gachaDetailList.Bag?.Date ?? DateTime.MinValue;
            }
            else if (gachaDetailList.ExchangeRecordId != null)
            {
                return gachaDetailList.ExchangeRecord.ExchangeDate ?? DateTime.MinValue;
            }
            else if (gachaDetailList.UploadRecordId != null)
            {
                return gachaDetailList.UploadRecord.UploadDate ?? DateTime.MinValue;
            }
            return DateTime.MinValue;
        }

        // PUT: api/GachaDetailLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGachaDetailList(int id, GachaDetailList gachaDetailList)
        {
            if (id != gachaDetailList.Id)
            {
                return BadRequest();
            }

            _context.Entry(gachaDetailList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GachaDetailListExists(id))
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

        // POST: api/GachaDetailLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GachaDetailList>> PostGachaDetailList(GachaDetailList gachaDetailList)
        {
            _context.GachaDetailLists.Add(gachaDetailList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGachaDetailList", new { id = gachaDetailList.Id }, gachaDetailList);
        }

        // DELETE: api/GachaDetailLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGachaDetailList(int id)
        {
            var gachaDetailList = await _context.GachaDetailLists.FindAsync(id);
            if (gachaDetailList == null)
            {
                return NotFound();
            }

            _context.GachaDetailLists.Remove(gachaDetailList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GachaDetailListExists(int id)
        {
            return _context.GachaDetailLists.Any(e => e.Id == id);
        }
    }
}
