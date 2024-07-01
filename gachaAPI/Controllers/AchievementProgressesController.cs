using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gachaAPI.Models;
using NuGet.Protocol.Plugins;
using gachaAPI.DTO;

namespace gachaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementProgressesController : ControllerBase
    {
        private readonly gachaContext _context;

        public AchievementProgressesController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/AchievementProgresses
        [HttpGet]
        public async Task<IEnumerable<AchievementProgressDTO>> GetAchievementProgresses()
        {
            return _context.AchievementProgresses.Select(ap => new AchievementProgressDTO
            {
                Id = ap.Id,
                UserId = ap.UserId,
                AchievementId = ap.AchievementId,
                Progress = ap.Progress,
                Target = ap.Target
            });
        }

        // GET: api/AchievementProgresses/5
        [HttpGet("{id}")]
        public async Task<AchievementProgressDTO> GetAchievementProgress(int id)
        {
            var achievementProgress = await _context.AchievementProgresses.FindAsync(id);

            if (achievementProgress == null)
            {
                return null;
            }

            AchievementProgressDTO achievementProgressDTO = new AchievementProgressDTO()
            {
                Id = achievementProgress.Id,
                UserId = achievementProgress.UserId,
                AchievementId = achievementProgress.AchievementId,
                Progress = achievementProgress.Progress,
                Target = achievementProgress.Target
            };

            return achievementProgressDTO;
        }

        // PUT: api/AchievementProgresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutAchievementProgress(int id, AchievementProgressDTO achievementProgressDTO)
        {
            if (id != achievementProgressDTO.Id || achievementProgressDTO.UserId == 0 || achievementProgressDTO.AchievementId == 0)
            {
                return "修改用戶成就進度失敗!";
            }

            AchievementProgress achievementProgress = await _context.AchievementProgresses.FindAsync(id);

            if (achievementProgress == null)
            {
                return "修改用戶成就進度失敗!";
            }

            achievementProgress.UserId = achievementProgressDTO.UserId;
            achievementProgress.AchievementId = achievementProgressDTO.AchievementId;
            achievementProgress.Progress = achievementProgressDTO.Progress;
            achievementProgressDTO.Target = achievementProgress.Target;

            _context.Entry(achievementProgress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchievementProgressExists(id))
                {
                    return "修改用戶成就進度失敗!";
                }
                else
                {
                    return "修改用戶成就進度失敗!";
                }
            }

            return "修改用戶成就進度成功!";
        }

        // POST: api/AchievementProgresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostAchievementProgress(AchievementProgressDTO achievementProgressDTO)
        {
            AchievementProgress achievementProgress = new AchievementProgress() 
            {
                UserId = achievementProgressDTO.UserId,
                AchievementId = achievementProgressDTO.AchievementId,
                Progress = achievementProgressDTO.Progress,
                Target = achievementProgressDTO.Target
            };



            _context.AchievementProgresses.Add(achievementProgress);
            await _context.SaveChangesAsync();

            return $"新增用戶成就進度成功! ID : {achievementProgress.Id}";
        }

        // DELETE: api/AchievementProgresses/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteAchievementProgress(int id)
        {
            var achievementProgress = await _context.AchievementProgresses.FindAsync(id);
            if (achievementProgress == null)
            {
                return "刪除用戶成就進度失敗!";
            }

            _context.AchievementProgresses.Remove(achievementProgress);
            await _context.SaveChangesAsync();

            return "刪除用戶成就進度成功!";
        }

        private bool AchievementProgressExists(int id)
        {
            return _context.AchievementProgresses.Any(e => e.Id == id);
        }
    }
}
