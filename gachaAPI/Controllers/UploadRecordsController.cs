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
    public class UploadRecordsController : ControllerBase
    {
        private readonly gachaContext _context;

        public UploadRecordsController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/UploadRecords
        [HttpGet]
        public async Task<IEnumerable<UploadRecordDTO>> GetUploadRecords()
        {
            return _context.UploadRecords.Select(ur => new UploadRecordDTO
            {
                Id = ur.Id,
                BagId = ur.BagId,
                UploadDate = ur.UploadDate
            });
        }

        // GET: api/UploadRecords/5
        [HttpGet("{id}")]
        public async Task<UploadRecordDTO> GetUploadRecord(int id)
        {
            var uploadRecord = await _context.UploadRecords.FindAsync(id);

            if (uploadRecord == null)
            {
                return null;
            }

            UploadRecordDTO uploadRecordDTO = new UploadRecordDTO()
            {
                Id = uploadRecord.Id,
                BagId = uploadRecord.BagId,
                UploadDate = uploadRecord.UploadDate
            };

            return uploadRecordDTO;
        }

        // PUT: api/UploadRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutUploadRecord(int id, UploadRecordDTO uploadRecordDTO)
        {
            if (id != uploadRecordDTO.Id || uploadRecordDTO.BagId == 0)
            {
                return "修改上架紀錄失敗!";
            }

            UploadRecord uploadRecord = await _context.UploadRecords.FindAsync(id);

            if (uploadRecord == null) 
            {
                return "修改上架紀錄失敗!";
            }

            uploadRecord.BagId = uploadRecordDTO.BagId;
            uploadRecord.UploadDate = DateTime.Now;

            _context.Entry(uploadRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UploadRecordExists(id))
                {
                    return "修改上架紀錄失敗!";
                }
                else
                {
                    return "修改上架紀錄失敗!";
                }
            }

            return "修改上架紀錄成功!";
        }

        // POST: api/UploadRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostUploadRecord(UploadRecordDTO uploadRecordDTO)
        {
            UploadRecord uploadRecord = new UploadRecord() 
            {
                BagId = uploadRecordDTO.BagId,
                UploadDate = DateTime.Now
            };



            _context.UploadRecords.Add(uploadRecord);
            await _context.SaveChangesAsync();

            return $"新增上架紀錄成功! ID : {uploadRecord.Id}";
        }

        // DELETE: api/UploadRecords/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteUploadRecord(int id)
        {
            var uploadRecord = await _context.UploadRecords.FindAsync(id);
            if (uploadRecord == null)
            {
                return "刪除上架紀錄失敗!";
            }

            _context.UploadRecords.Remove(uploadRecord);
            await _context.SaveChangesAsync();

            return "刪除上架紀錄成功!";
        }

        private bool UploadRecordExists(int id)
        {
            return _context.UploadRecords.Any(e => e.Id == id);
        }
    }
}
