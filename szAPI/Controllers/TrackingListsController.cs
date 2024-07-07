using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/TrackingLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrackingList>> GetTrackingList(int id)
        {
            var trackingList = await _context.TrackingLists.FindAsync(id);

            if (trackingList == null)
            {
                return NotFound();
            }

            return trackingList;
        }

        // PUT: api/TrackingLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrackingList>> PostTrackingList(TrackingList trackingList)
        {
            _context.TrackingLists.Add(trackingList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrackingListExists(trackingList.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrackingList", new { id = trackingList.UserId }, trackingList);
        }

        // DELETE: api/TrackingLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrackingList(int id)
        {
            var trackingList = await _context.TrackingLists.FindAsync(id);
            if (trackingList == null)
            {
                return NotFound();
            }

            _context.TrackingLists.Remove(trackingList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrackingListExists(int id)
        {
            return _context.TrackingLists.Any(e => e.UserId == id);
        }
    }
}
