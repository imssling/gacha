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
    public class CheckInsController : ControllerBase
    {
        private readonly gachaContext _context;

        public CheckInsController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/CheckIns
        [HttpGet]
        public async Task<IEnumerable<CheckInDTO>> GetCheckIns()
        {
            return _context.CheckIns.Select(ci => new CheckInDTO
            {
                Id = ci.Id,
                UserId = ci.UserId,
                CheckInDate = ci.CheckInDate
            });
        }

        // GET: api/CheckIns/5
        [HttpGet("{id}")]
        public async Task<CheckInDTO> GetCheckIn(int id)
        {
            var checkIn = await _context.CheckIns.FindAsync(id);

            if (checkIn == null)
            {
                return null;
            }

            CheckInDTO checkInDTO = new CheckInDTO()
            {
                Id = checkIn.Id,
                UserId = checkIn.UserId,
                CheckInDate = checkIn.CheckInDate
            };

            return checkInDTO;
        }

        // PUT: api/CheckIns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutCheckIn(int id, CheckInDTO checkInDTO)
        {
            if (id != checkInDTO.Id || checkInDTO.UserId == 0)
            {
                return "修改簽到失敗!";
            }

            CheckIn checkIn = await _context.CheckIns.FindAsync(id);

            if (checkIn == null) 
            {
                return "修改簽到失敗!";
            }

            checkIn.UserId = checkInDTO.UserId;


            _context.Entry(checkIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckInExists(id))
                {
                    return "修改簽到失敗!";
                }
                else
                {
                    return "修改簽到失敗!";
                }
            }

            return "修改簽到成功!";
        }

        // POST: api/CheckIns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostCheckIn(CheckInDTO checkInDTO)
        {
            CheckIn checkIn = new CheckIn()
            {
                UserId = checkInDTO.UserId,
                CheckInDate = DateTime.Now
            };



            _context.CheckIns.Add(checkIn);
            await _context.SaveChangesAsync();

            return $"新增簽到成功! ID : {checkIn.Id}";
        }

        // DELETE: api/CheckIns/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteCheckIn(int id)
        {
            var checkIn = await _context.CheckIns.FindAsync(id);
            if (checkIn == null)
            {
                return "刪除簽到失敗!";
            }

            _context.CheckIns.Remove(checkIn);
            await _context.SaveChangesAsync();

            return "刪除簽到成功!";
        }

        private bool CheckInExists(int id)
        {
            return _context.CheckIns.Any(e => e.Id == id);
        }
    }
}
