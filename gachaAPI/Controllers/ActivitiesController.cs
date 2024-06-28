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
    public class ActivitiesController : ControllerBase
    {
        private readonly gachaContext _context;

        public ActivitiesController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<IEnumerable<ActivityDTO>> GetActivities()
        {


            //return _context.Activities;


            return _context.Activities.Select(a => new ActivityDTO
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                Status = a.Status,
                ActivityTypeId = a.ActivityTypeId,
                ActivityStart = a.ActivityStart,
                ActivityEnd = a.ActivityEnd,
                CreatedAt = a.CreatedAt
            });
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDTO>> GetActivity(int id)
        {
            var activity = await _context.Activities.FindAsync(id);

            ActivityDTO activityDTO = new ActivityDTO()
            {
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                Status = activity.Status,
                ActivityTypeId = activity.ActivityTypeId,
                ActivityStart = activity.ActivityStart,
                ActivityEnd = activity.ActivityEnd,
                CreatedAt = activity.CreatedAt
            };

            if (activity == null)
            {
                return NotFound();
            }

            return activityDTO;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutActivity(int id, ActivityDTO activityDTO)
        {
            if (id != activityDTO.Id)
            {
                return "修改活動失敗!";//848
            }

            var tmpActicity = _context.Activities.Find(id);

            //if (tmpActivity != null)
            //{
            //    var tmpDate = tmpActivity.CreatedAt;
            //}

            Activity activity = new Activity()
            {
                Id = activityDTO.Id,
                Title = activityDTO.Title,
                Description = activityDTO.Description,
                Status = activityDTO.Status,
                ActivityTypeId = activityDTO.ActivityTypeId,
                ActivityStart = activityDTO.ActivityStart,
                ActivityEnd = activityDTO.ActivityEnd,

            };

            if (tmpActicity.CreatedAt != null)
            {
                activity.CreatedAt = tmpActicity.CreatedAt;
            }


            _context.Entry(tmpActicity).State = EntityState.Deleted;



            _context.Entry(activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
                {
                    return "修改活動失敗!";
                }
                else
                {
                    throw;
                }
            }

            return "修改活動成功!";
        }

        // POST: api/Activities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostActivity(ActivityDTO activityDTO)
        {

            Activity activity = new Activity()
            {
                Title = activityDTO.Title,
                Description = activityDTO.Description,
                Status = activityDTO.Status,
                ActivityTypeId = activityDTO.ActivityTypeId,
                ActivityStart = activityDTO.ActivityStart,
                ActivityEnd = activityDTO.ActivityEnd
            };



            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();

            return $"新增活動成功! ID : {activity.Id}";
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteActivity(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return "刪除活動失敗";
            }

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();

            return "刪除活動成功";
        }

        private bool ActivityExists(int id)
        {
            return _context.Activities.Any(e => e.Id == id);
        }
    }
}
