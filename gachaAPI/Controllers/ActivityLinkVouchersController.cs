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
        public async Task<ActionResult<ActivityLinkVoucher>> GetActivityLinkVoucher(int id)
        {
            var activityLinkVoucher = await _context.ActivityLinkVouchers.FindAsync(id);

            if (activityLinkVoucher == null)
            {
                return NotFound();
            }

            return activityLinkVoucher;
        }

        // PUT: api/ActivityLinkVouchers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityLinkVoucher(int id, ActivityLinkVoucher activityLinkVoucher)
        {
            if (id != activityLinkVoucher.Id)
            {
                return BadRequest();
            }

            _context.Entry(activityLinkVoucher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityLinkVoucherExists(id))
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

        // POST: api/ActivityLinkVouchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivityLinkVoucher>> PostActivityLinkVoucher(ActivityLinkVoucher activityLinkVoucher)
        {
            _context.ActivityLinkVouchers.Add(activityLinkVoucher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityLinkVoucher", new { id = activityLinkVoucher.Id }, activityLinkVoucher);
        }

        // DELETE: api/ActivityLinkVouchers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityLinkVoucher(int id)
        {
            var activityLinkVoucher = await _context.ActivityLinkVouchers.FindAsync(id);
            if (activityLinkVoucher == null)
            {
                return NotFound();
            }

            _context.ActivityLinkVouchers.Remove(activityLinkVoucher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityLinkVoucherExists(int id)
        {
            return _context.ActivityLinkVouchers.Any(e => e.Id == id);
        }
    }
}
