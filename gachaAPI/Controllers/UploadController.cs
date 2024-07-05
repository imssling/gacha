using Microsoft.AspNetCore.Mvc;
using gachaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gachaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly gachaContext _context;

        public UploadController(gachaContext context)
        {
            _context = context;
        }




        // GET: api/<UploadController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UploadController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UploadController>
        [HttpPost]
        public async Task<string> Upload(int intBagId)
        {
            var bag = await _context.Bags.FindAsync(intBagId);

            if (bag == null)
            {
                return "上架失敗!";
            }

            else
            {
                bag.GachaStatus = "已上架";


                _context.Entry(bag).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BagExists(intBagId))
                    {
                        return "上架失敗!";
                    }
                    else
                    {
                        return "上架失敗!";
                    }
                }

                UploadRecord uploadRecord = new UploadRecord() 
                {
                    BagId = intBagId
                };

                _context.UploadRecords.Add(uploadRecord);
                await _context.SaveChangesAsync();

                return "上架成功!";
            }

        }

        private bool BagExists(int id)
        {
            return _context.Bags.Any(e => e.Id == id);
        }

        // PUT api/<UploadController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UploadController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
