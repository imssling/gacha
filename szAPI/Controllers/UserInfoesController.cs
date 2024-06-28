using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Identity;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using szAPI.DTO;
using szAPI.Models;

namespace szAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoesController : ControllerBase
    {
        private readonly gachaContext _context;

        public UserInfoesController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/UserInfoes
        [HttpGet]
        public async Task<IEnumerable<UserInfoDTO>> GetUserInfos()
        {
            return _context.UserInfos.Select(UserInfos => new UserInfoDTO
            {
                id = UserInfos.Id,
                userName = UserInfos.UserName,
                phoneNumber = UserInfos.PhoneNumber,
                email = UserInfos.Email,
                address = UserInfos.Address,
                gender = UserInfos.Gender,
            });
        }

        // GET: api/UserInfoes/5
        [HttpGet("{id}")]
        public async Task<UserInfoDTO> GetUserInfo(int id)
        {
            var userInfo = await _context.UserInfos.FindAsync(id);
            UserInfoDTO userInfoDTO = new UserInfoDTO
            {
                id = userInfo.Id,
                userName = userInfo.UserName,
                phoneNumber = userInfo.PhoneNumber,
                email = userInfo.Email,
                address = userInfo.Address,
                gender = userInfo.Gender,
            };
            if (userInfo == null)
            {
                return null;
            }

            return userInfoDTO;
        }

        // PUT: api/UserInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo(int id, UserInfo userInfo)
        {
            if (id != userInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
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

        // POST: api/UserInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUserInfo(UserInfo userInfo)
        {
            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfo", new { id = userInfo.Id }, userInfo);
        }

        // DELETE: api/UserInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo(int id)
        {
            var userInfo = await _context.UserInfos.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            _context.UserInfos.Remove(userInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInfoExists(int id)
        {
            return _context.UserInfos.Any(e => e.Id == id);
        }
    }
}
