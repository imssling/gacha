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
    public class ExchangeRecordsController : ControllerBase
    {
        private readonly gachaContext _context;

        public ExchangeRecordsController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/ExchangeRecords
        [HttpGet]
        public async Task<IEnumerable<ExchangeRecordDTO>> GetExchangeRecords()
        {
            return _context.ExchangeRecords.Select(er => new ExchangeRecordDTO
            {
                Id = er.Id,
                UserIdFrom = er.UserIdFrom,
                UserIdTo = er.UserIdTo,
                GachaIdFrom = er.GachaIdFrom,
                GachaIdTo = er.GachaIdTo,
                ExchangeDate = er.ExchangeDate
            });
        }

        // GET: api/ExchangeRecords/5
        [HttpGet("{id}")]
        public async Task<ExchangeRecordDTO> GetExchangeRecord(int id)
        {
            var exchangeRecord = await _context.ExchangeRecords.FindAsync(id);

            if (exchangeRecord == null)
            {
                return null;
            }


            ExchangeRecordDTO exchangeRecordDTO = new ExchangeRecordDTO()
            {
                Id = exchangeRecord.Id,
                UserIdFrom = exchangeRecord.UserIdFrom,
                UserIdTo = exchangeRecord.UserIdTo,
                GachaIdFrom= exchangeRecord.GachaIdFrom,
                GachaIdTo= exchangeRecord.GachaIdTo,
                ExchangeDate = exchangeRecord.ExchangeDate
            };

            return exchangeRecordDTO;
        }

        // PUT: api/ExchangeRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutExchangeRecord(int id, ExchangeRecordDTO exchangeRecordDTO)
        {
            if (id != exchangeRecordDTO.Id || exchangeRecordDTO.UserIdFrom == 0 || exchangeRecordDTO.UserIdTo == 0 || exchangeRecordDTO.GachaIdFrom == 0 || exchangeRecordDTO.GachaIdTo == 0)
            {
                return "修改交換紀錄失敗!";
            }

            ExchangeRecord exchangeRecord = await _context.ExchangeRecords.FindAsync(id);

            if (exchangeRecord == null) 
            {
                return "修改交換紀錄失敗!";
            }

            exchangeRecord.UserIdFrom = exchangeRecordDTO.UserIdFrom;
            exchangeRecord.UserIdTo = exchangeRecordDTO.UserIdTo;
            exchangeRecord.GachaIdFrom = exchangeRecordDTO.GachaIdFrom;
            exchangeRecord.GachaIdTo = exchangeRecordDTO.GachaIdTo;


            _context.Entry(exchangeRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExchangeRecordExists(id))
                {
                    return "修改交換紀錄失敗!";
                }
                else
                {
                    return "修改交換紀錄失敗!";
                }
            }

            return "修改交換紀錄成功!";
        }

        // POST: api/ExchangeRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostExchangeRecord(ExchangeRecordDTO exchangeRecordDTO)
        {

            ExchangeRecord exchangeRecord = new ExchangeRecord()
            {
                UserIdFrom = exchangeRecordDTO.UserIdFrom,
                UserIdTo = exchangeRecordDTO.UserIdTo,
                GachaIdFrom = exchangeRecordDTO.GachaIdFrom,
                GachaIdTo = exchangeRecordDTO.GachaIdTo
            };



            _context.ExchangeRecords.Add(exchangeRecord);
            await _context.SaveChangesAsync();

            return $"新增交換紀錄成功! ID : {exchangeRecord.Id}";
        }

        // DELETE: api/ExchangeRecords/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteExchangeRecord(int id)
        {
            var exchangeRecord = await _context.ExchangeRecords.FindAsync(id);
            if (exchangeRecord == null)
            {
                return "刪除交換紀錄失敗!";
            }

            _context.ExchangeRecords.Remove(exchangeRecord);
            await _context.SaveChangesAsync();

            return "刪除交換紀錄成功!";
        }

        private bool ExchangeRecordExists(int id)
        {
            return _context.ExchangeRecords.Any(e => e.Id == id);
        }
    }
}
