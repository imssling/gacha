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
    public class TrackingListsController : ControllerBase
    {
        private readonly gachaContext _context;

        public TrackingListsController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/TrackingLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackingList>>> GetTrackingLists()
        {
            return await _context.TrackingLists.ToListAsync();
        }

        //透過使用者ID找出其追蹤清單
        // GET: api/TrackingLists/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<TrackingListDTO>>> GetTrackingListByUserId(int userId)
        {
            var trackingList = await _context.TrackingLists
                .Include(tl => tl.GachaMachine)
                .Where(tl => tl.UserId == userId)
                .Select(tl => new TrackingListDTO
                {
                    userId = tl.UserId,
                    gachaMachineId = tl.GachaMachineId,
                    gachaMachineName = tl.GachaMachine.MachineName,
                    price = tl.GachaMachine.Price,
                })
               .ToListAsync();

            if (trackingList == null)
            {
                return null;
            }

            return trackingList;
        }

        // PUT: api/TrackingLists/5
        // To protect from overposting attacks, see <https://go.microsoft.com/fwlink/?linkid=2123754>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrackingList(int id, TrackingList trackingList)
        {
            if (id != trackingList.UserId)
            {
                return BadRequest();
            }

            _context.Entry(trackingList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackingListExists(id))
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

        // POST: api/TrackingLists
        // To protect from overposting attacks, see <https://go.microsoft.com/fwlink/?linkid=2123754>
        [HttpPost]
        public async Task<ActionResult<string>> PostTrackingList(TrackingListDTO trackingListDTO)
        {
            // 檢查是否已經存在相同的追蹤記錄
            var existingTrackingList = await _context.TrackingLists
                .FirstOrDefaultAsync(tl => tl.UserId == trackingListDTO.userId && tl.GachaMachineId == trackingListDTO.gachaMachineId);

            if (existingTrackingList != null)
            {
                return "此追蹤記錄已存在";
            }

            // 取得相應的 GachaMachine 實體
            var gachaMachine = await _context.GachaMachines.FindAsync(trackingListDTO.gachaMachineId);

            // 創建 TrackingList 實體
            TrackingList trackingList = new TrackingList
            {
                UserId = trackingListDTO.userId,
                GachaMachineId = trackingListDTO.gachaMachineId,
                TrackingDate = DateTime.Now,
                NoteStatus = "已追蹤"
            };

            _context.TrackingLists.Add(trackingList);
            await _context.SaveChangesAsync();

            return "成功新增追蹤清單!";
        }

        // DELETE: api/TrackingLists/{userId}/{gachaMachineId}
        [HttpDelete("{userId}/{gachaMachineId}")]
        public async Task<string> DeleteTrackingList(int userId, int gachaMachineId)
        {
            var trackingList = await _context.TrackingLists
                .Where(tl => tl.UserId == userId && tl.GachaMachineId == gachaMachineId)
                .FirstOrDefaultAsync();

            if (trackingList == null)
            {
                return "找不到要刪除的追蹤清單!";
            }

            _context.TrackingLists.Remove(trackingList);
            await _context.SaveChangesAsync();

            return "刪除成功!";
        }

        private bool TrackingListExists(int id)
        {
            return _context.TrackingLists.Any(e => e.UserId == id);
        }
    }
}
