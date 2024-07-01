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
    public class UserAchievementsController : ControllerBase
    {
        private readonly gachaContext _context;

        public UserAchievementsController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/UserAchievements
        [HttpGet]
        public async Task<IEnumerable<UserAchievementDTO>> GetUserAchievements()
        {
            return _context.UserAchievements.Select(ua => new UserAchievementDTO
            {
                Id = ua.Id,
                UserId = ua.UserId,
                AchievementId = ua.AchievementId,
                AchievedAt = ua.AchievedAt
            });
        }

        // GET: api/UserAchievements/5
        [HttpGet("{id}")]
        public async Task<UserAchievementDTO> GetUserAchievement(int id)
        {
            var userAchievement = await _context.UserAchievements.FindAsync(id);

            if (userAchievement == null)
            {
                return null;
            }

            UserAchievementDTO userAchievementDTO = new UserAchievementDTO() 
            {
                Id = userAchievement.Id,
                UserId = userAchievement.UserId,
                AchievementId = userAchievement.AchievementId,
                AchievedAt = userAchievement.AchievedAt
            };

            return userAchievementDTO;
        }

        // PUT: api/UserAchievements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutUserAchievement(int id, UserAchievementDTO userAchievementDTO)
        {
            if (id != userAchievementDTO.Id)
            {
                return "修改使用者成就失敗!";
            }

            UserAchievement userAchievement = await _context.UserAchievements.FindAsync(id);

            if (userAchievement == null) 
            {
                return "修改使用者成就失敗!";
            }

            userAchievement.UserId = userAchievementDTO.UserId;
            userAchievement.AchievementId = userAchievementDTO.AchievementId;
            


            _context.Entry(userAchievement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAchievementExists(id))
                {
                    return "修改使用者成就失敗!";
                }
                else
                {
                    return "修改使用者成就失敗!";
                }
            }

            return "修改使用者成就成功!";
        }

        // POST: api/UserAchievements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostUserAchievement(UserAchievementDTO userAchievementDTO)
        {
            UserAchievement userAchievement = new UserAchievement() 
            {
                UserId = userAchievementDTO.UserId,
                AchievementId = userAchievementDTO.AchievementId,
                AchievedAt = DateTime.Now
            };



            _context.UserAchievements.Add(userAchievement);
            await _context.SaveChangesAsync();

            return $"新增用戶成就成功! ID : {userAchievement.Id}";
        }

        // DELETE: api/UserAchievements/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteUserAchievement(int id)
        {
            var userAchievement = await _context.UserAchievements.FindAsync(id);
            if (userAchievement == null)
            {
                return "刪除使用者成就失敗!";
            }

            _context.UserAchievements.Remove(userAchievement);
            await _context.SaveChangesAsync();

            return "刪除使用者成就成功!";
        }

        private bool UserAchievementExists(int id)
        {
            return _context.UserAchievements.Any(e => e.Id == id);
        }
    }
}
