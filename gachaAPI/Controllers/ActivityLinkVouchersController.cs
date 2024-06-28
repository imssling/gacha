using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gachaAPI.Models;
using gachaAPI.DTO;

namespace gachaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLinkVouchersController : ControllerBase
    {
        private readonly gachaContext _context;

        public ActivityLinkVouchersController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/ActivityLinkVouchers
        [HttpGet]
        public async Task<IEnumerable<ActivityLinkVoucherDTO>> GetActivityLinkVouchers()
        {
            return _context.ActivityLinkVouchers.Select(alv => new ActivityLinkVoucherDTO 
            {
                Id = alv.Id,
                ActivityId = alv.ActivityId,
                VoucherId = alv.VoucherId
            });
        }

        // GET: api/ActivityLinkVouchers/5
        [HttpGet("{id}")]
        public async Task<ActivityLinkVoucherDTO> GetActivityLinkVoucher(int id)
        {
            var activityLinkVoucher = await _context.ActivityLinkVouchers.FindAsync(id);

            if (activityLinkVoucher == null)
            {
                return null;
            }

            ActivityLinkVoucherDTO activityLinkVoucherDTO = new ActivityLinkVoucherDTO
            {
                Id = activityLinkVoucher.Id,
                ActivityId = activityLinkVoucher.ActivityId,
                VoucherId = activityLinkVoucher.VoucherId
            };

            return activityLinkVoucherDTO;
        }

        // PUT: api/ActivityLinkVouchers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutActivityLinkVoucher(int id, ActivityLinkVoucherDTO activityLinkVoucherDTO)
        {
            if (id != activityLinkVoucherDTO.Id)
            {
                return "修改活動與優惠關聯失敗!";
            }

            ActivityLinkVoucher activityLinkVoucher = await _context.ActivityLinkVouchers.FindAsync(id);

            activityLinkVoucher.ActivityId = activityLinkVoucherDTO.ActivityId;
            activityLinkVoucher.VoucherId = activityLinkVoucherDTO.VoucherId;



            _context.Entry(activityLinkVoucher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityLinkVoucherExists(id))
                {
                    return "修改活動與優惠關聯失敗!";
                }
                else
                {
                    throw;
                }
            }

            return "修改活動與優惠關聯成功!";
        }

        // POST: api/ActivityLinkVouchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostActivityLinkVoucher(ActivityLinkVoucherDTO activityLinkVoucherDTO)
        {

            ActivityLinkVoucher activityLinkVoucher = new ActivityLinkVoucher() 
            {
                Id = activityLinkVoucherDTO.Id,
                ActivityId = activityLinkVoucherDTO.ActivityId,
                VoucherId = activityLinkVoucherDTO.VoucherId
            
            };


            _context.ActivityLinkVouchers.Add(activityLinkVoucher);
            await _context.SaveChangesAsync();

            return $"成功建立活動與優惠的關聯 ID:{activityLinkVoucher.Id}";
        }

        // DELETE: api/ActivityLinkVouchers/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteActivityLinkVoucher(int id)
        {
            var activityLinkVoucher = await _context.ActivityLinkVouchers.FindAsync(id);
            if (activityLinkVoucher == null)
            {
                return "刪除活動與優惠的關聯失敗!";
            }

            _context.ActivityLinkVouchers.Remove(activityLinkVoucher);
            await _context.SaveChangesAsync();

            return "刪除活動與優惠的關聯成功!";
        }

        private bool ActivityLinkVoucherExists(int id)
        {
            return _context.ActivityLinkVouchers.Any(e => e.Id == id);
        }
    }
}
