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

        // GET: api/GachaDetailLists/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<GachaDetailListDTO>>> GetGachaDetailListByUserId(int userId)
        {
            var gachaDetailList = await _context.GachaDetailLists
                .Where(gdl => gdl.Bag.UserId == userId || gdl.ExchangeRecord.UserIdFrom == userId || gdl.UploadRecord.Bag.UserId == userId || gdl.ShippingDetail.Shipping.UserId == userId)
                .Include(gdl => gdl.ExchangeRecord)
                .Include(gdl => gdl.UploadRecord)
                .Include(gdl => gdl.Bag)
                    .ThenInclude(b => b.GachaProduct)
                .Include(gdl => gdl.ShippingDetail)
                    .ThenInclude(sd => sd.Shipping)
                .ToListAsync();

            if (gachaDetailList == null)
            {
                return NotFound(new { message = "找不到該使用者的任何扭蛋異動紀錄。" });
            }

            // 轉換為 DTO 格式以便返回
            var gachaDetailListDTO = gachaDetailList
                .GroupBy(gdl => new {
                    ProductName = gdl.Bag?.GachaProduct?.ProductName ?? "未知商品",
                    Date = gdl.Bag?.Date ?? DateTime.MinValue
                })
                .Select(g => new GachaDetailListDTO
                {
                    id = g.First().Id,
                    gachaProductName = g.Key.ProductName,
                    status = ConfirmStatus(g.First()),
                    quantity = g.Count(),
                    updateTime = ConfirmUpdateTime(g.First()),
                })
                .ToList();

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
                return "已交換";
            }
            else if (gachaDetailList.UploadRecordId != null)
            {
                return "已上架";
            }
            else if (gachaDetailList.ShippingDetailId != null)
            {
                return "已出貨";
            }
            else
            {
                return "找無此資料!";
            }
        }

        private DateTime ConfirmUpdateTime(GachaDetailList gachaDetailList)
        {
            if (gachaDetailList.BagId != null && gachaDetailList.Bag != null)
            {
                return gachaDetailList.Bag.Date;
            }
            else if (gachaDetailList.ExchangeRecordId != null && gachaDetailList.ExchangeRecord != null)
            {
                return gachaDetailList.ExchangeRecord.ExchangeDate ?? DateTime.MinValue;
            }
            else if (gachaDetailList.UploadRecordId != null && gachaDetailList.UploadRecord != null)
            {
                return gachaDetailList.UploadRecord.UploadDate ?? DateTime.MinValue;
            }
            else if (gachaDetailList.ShippingDetailId != null && gachaDetailList.ShippingDetail?.Shipping != null)
            {
                return gachaDetailList.ShippingDetail.Shipping.ShippingDate ?? DateTime.MinValue;
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
