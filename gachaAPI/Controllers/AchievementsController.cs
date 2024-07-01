using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gachaAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using gachaAPI.DTO;

namespace gachaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        private readonly gachaContext _context;

        public AchievementsController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/Achievements
        [HttpGet]
        public async Task<IEnumerable<AchievementDTO>> GetAchievements()
        {
            return _context.Achievements.Select(a => new AchievementDTO
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                AchievementType = a.AchievementType,
                Target = a.Target,
                CreatedAt = a.CreatedAt
            });
        }

        // GET: api/Achievements/5
        [HttpGet("{id}")]
        public async Task<AchievementDTO> GetAchievement(int id)
        {
            var achievement = await _context.Achievements.FindAsync(id);

            if (achievement == null)
            {
                return null;
            }

            AchievementDTO achievementDTO = new AchievementDTO()
            {
                Id = achievement.Id,
                Name = achievement.Name,
                Description = achievement.Description,
                AchievementType = achievement.AchievementType,
                Target = achievement.Target,
                CreatedAt = achievement.CreatedAt
            };


            return achievementDTO;
        }

        // PUT: api/Achievements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutAchievement(int id, AchievementDTO achievementDTO)
        {
            if (id != achievementDTO.Id)
            {
                return "修改成就失敗!";
            }

            Achievement achievement = await _context.Achievements.FindAsync(id);

            if (achievement == null)
            {
                return "修改成就失敗!";
            }

            achievement.Name = achievementDTO.Name;
            achievement.Description = achievementDTO.Description;
            achievement.AchievementType = achievementDTO.AchievementType;
            achievement.Target = achievementDTO.Target;
            achievement.CreatedAt = DateTime.Now;


            _context.Entry(achievement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchievementExists(id))
                {
                    return "修改成就失敗!";
                }
                else
                {
                    return "修改成就失敗!";
                }
            }

            return "修改成就成功!";
        }

        // POST: api/Achievements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostAchievement(AchievementDTO achievementDTO)
        {
            Achievement achievement = new Achievement() 
            {
                Name = achievementDTO.Name,
                Description = achievementDTO.Description,
                AchievementType = achievementDTO.AchievementType,
                Target = achievementDTO.Target,
                CreatedAt = achievementDTO.CreatedAt
            };


            _context.Achievements.Add(achievement);
            await _context.SaveChangesAsync();

            return $"新增成就成功! ID : {achievement.Id}";
        }

        // DELETE: api/Achievements/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteAchievement(int id)
        {
            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return "刪除成就失敗!";
            }

            _context.Achievements.Remove(achievement);
            await _context.SaveChangesAsync();

            return "刪除成就成功!";
        }

        private bool AchievementExists(int id)
        {
            return _context.Achievements.Any(e => e.Id == id);
        }
    }
}
