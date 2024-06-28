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
        public async Task<ActivityType> GetActivityType(int id)
        {




            var activityType = await _context.ActivityTypes.FindAsync(id);

            if (activityType == null)
            {
                return null;
            }

            return activityType;
        }

        // PUT: api/ActivityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutActivityType(int id, ActivityTypeDTO activityTypeDTO)
        {
            if (id != activityTypeDTO.Id)
            {
                return "修改活動類別失敗!";
            }


            ActivityType activityType = await _context.ActivityTypes.FindAsync(id);

            activityType.Id = activityTypeDTO.Id;
            activityType.Name = activityTypeDTO.Name;
            //activityType.CreatedAt = DateTime.Now;
            

            _context.Entry(activityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityTypeExists(id))
                {
                    return "修改活動類別失敗!";
                }
                else
                {
                    throw;
                }
            }

            return "修改活動類別成功!";
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

            return $"建立活動類別成功! ID:{activityType.Id}";
        }

        // DELETE: api/ActivityTypes/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteActivityType(int id)
        {
            var activityType = await _context.ActivityTypes.FindAsync(id);
            if (activityType == null)
            {
                return "刪除活動類別失敗!";
            }

            _context.ActivityTypes.Remove(activityType);
            await _context.SaveChangesAsync();

            return "刪除活動類別成功!";
        }

        private bool ActivityTypeExists(int id)
        {
            return _context.ActivityTypes.Any(e => e.Id == id);
        }
    }
}
