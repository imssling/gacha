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

        //查詢所有用戶資料
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

        //查詢個別用戶資料
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

        //更新個別用戶資料
        // PUT: api/UserInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutUserInfo(int id, UserInfoDTO userInfoDTO)
        {
            if (id != userInfoDTO.id)
            {
                return "會員資料錯誤!";
            }

            var userInfo = await _context.UserInfos.FindAsync(id);
            if (userInfo == null)
            {
                return "該會員資料不存在!";
            }

            userInfo.UserName = userInfoDTO.userName;
            userInfo.PhoneNumber = userInfoDTO.phoneNumber;
            userInfo.Email = userInfoDTO.email;
            userInfo.Address = userInfoDTO.address;
            userInfo.Gender = userInfoDTO.gender;

            _context.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
                {
                    return "該會員資料不存在!";
                }
                else
                {
                    throw;
                }
            }

            return "會員資料修改成功!";
        }

        //新增用戶資料
        // POST: api/UserInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostUserInfo(UserInfoDTO userInfoDTO)
        {
            UserInfo userInfo = new UserInfo
            {
                UserName = userInfoDTO.userName,
                PhoneNumber = userInfoDTO.phoneNumber,
                Email = userInfoDTO.email,
                Address = userInfoDTO.address,
                Gender = userInfoDTO.gender
            };


            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();

            return $"成功新增會員，會員編號為:{userInfo.Id}";
        }

        ////刪除用戶資料
        // DELETE: api/UserInfoes/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteUserInfo(int id)
        {
            var userInfo = await _context.UserInfos.FindAsync(id);
            if (userInfo == null)
            {
                return "找不到要刪除的會員資料!";
            }

            try
            {
                _context.UserInfos.Remove(userInfo);
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateException ex)
            { 
            return "刪除會員資料失敗!";
            }

            return "刪除會員資料成功!";
        }

        private bool UserInfoExists(int id)
        {
            return _context.UserInfos.Any(e => e.Id == id);
        }
    }
}
