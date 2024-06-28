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
    public class ActivityTypesController : ControllerBase
    {
        private readonly gachaContext _context;

        public ActivityTypesController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/ActivityTypes
        [HttpGet]
        public async Task<IEnumerable<ActivityTypeDTO>> GetActivityTypes()
        {


            return _context.ActivityTypes.Select(at => new ActivityTypeDTO
            {
                Id = at.Id,
                Name = at.Name

            });
        }

        // GET: api/ActivityTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityType>> GetActivityType(int id)
        {




            var activityType = await _context.ActivityTypes.FindAsync(id);

            if (activityType == null)
            {
                return NotFound();
            }

            return activityType;
        }

        // PUT: api/ActivityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityType(int id, ActivityTypeDTO activityTypeDTO)
        {
            if (id != activityTypeDTO.Id)
            {
                return BadRequest();
            }

            ActivityType activityType = new ActivityType()
            {
                Id = activityTypeDTO.Id,
                Name = activityTypeDTO.Name,
                CreatedAt = DateTime.UtcNow
            };

            _context.Entry(activityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityTypeExists(id))
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

        // POST: api/ActivityTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostActivityType(ActivityTypeDTO activityTypeDTO)
        {
            ActivityType activityType = new ActivityType()
            {
                Id = activityTypeDTO.Id,
                Name = activityTypeDTO.Name
            };



            _context.ActivityTypes.Add(activityType);
            await _context.SaveChangesAsync();

            return $"活動類別ID:{activityType.Id}";
        }

        // DELETE: api/ActivityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityType(int id)
        {
            var activityType = await _context.ActivityTypes.FindAsync(id);
            if (activityType == null)
            {
                return NotFound();
            }

            _context.ActivityTypes.Remove(activityType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityTypeExists(int id)
        {
            return _context.ActivityTypes.Any(e => e.Id == id);
        }
    }
}
