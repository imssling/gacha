using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using szAPI.DTO;
using szAPI.Models;

namespace szAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GachaMachinesController : ControllerBase
    {
        private readonly gachaContext _context;

        public GachaMachinesController(gachaContext context)
        {
            _context = context;
        }

        // 找出符合ID的機台照片
        // GET: api/GachaMachines/GetPicture/{id}
        [HttpGet("GetPicture/{id}")]
        public async Task<IActionResult> GetPicture(int id)
        {
            var gachaMachine = await _context.GachaMachines.FindAsync(id);
            if (gachaMachine == null || string.IsNullOrEmpty(gachaMachine.MachinePictureName))
            {
                return NotFound();
            }

            var path = Path.Combine("images", gachaMachine.MachinePictureName);
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var image = System.IO.File.OpenRead(path);
            return File(image, "image/jpeg");
        }

        // 找出所有機台資料
        // GET: api/GachaMachines
        [HttpGet]
        public async Task<IEnumerable<GachaMachineDTO>> GetGachaMachines()
        {
            return _context.GachaMachines
                .Select(Machine => new GachaMachineDTO
                 {
                    id = Machine.Id,
                    themeId = Machine.ThemeId,
                    machineName = Machine.MachineName,
                    machineDescription = Machine.MachineDescription,
                    machinePictureName = Machine.MachinePictureName,
                    createTime = (DateTime)Machine.CreateTime,
                    price = Machine.Price
                });
            
        }

        // 透過主題名稱搜尋機台
        // GET: api/GachaMachines/theme/{themename}
        [HttpGet("theme/{themename}")]
        public async Task<ActionResult<IEnumerable<GachaMachineDTObyTheme>>> GetGachaMachineByTheme(string themename)
        {
            var machines = await _context.GachaMachines
                .Include(gm => gm.Theme)
                .Where(gm => gm.Theme.ThemeName == themename)
                .Select(gmt => new GachaMachineDTObyTheme
                {
                    id = gmt.Id,
                    themeName = gmt.Theme.ThemeName,
                    machineName = gmt.MachineName,
                    machineDescription = gmt.MachineDescription,
                    machinePictureName= gmt.MachinePictureName,
                    price = gmt.Price
                })
                .ToListAsync();

            if (machines == null)
            {
                return null;
            }

            return machines;
        }

        // 透過價錢搜尋機台
        // GET: api/GachaMachines/{price}
        [HttpGet("{price}")]
        public async Task<ActionResult<IEnumerable<GachaMachineDTO>>> GetGachaMachineByPrice(int price)
        {
            var machines = await _context.GachaMachines
                .Where(gm => gm.Price == price)
                .Select(gmt => new GachaMachineDTO
                {
                    id = gmt.Id,
                    machineName = gmt.MachineName,
                    machineDescription = gmt.MachineDescription,
                    machinePictureName = gmt.MachinePictureName,
                    price = gmt.Price
                })
                .ToListAsync();

            if (machines == null)
            {
                return null;
            }

            return machines;
        }

        // PUT: api/GachaMachines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGachaMachine(int id, GachaMachine gachaMachine)
        {
            if (id != gachaMachine.Id)
            {
                return BadRequest();
            }

            _context.Entry(gachaMachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GachaMachineExists(id))
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

        // POST: api/GachaMachines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GachaMachine>> PostGachaMachine(GachaMachine gachaMachine)
        {
            _context.GachaMachines.Add(gachaMachine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGachaMachine", new { id = gachaMachine.Id }, gachaMachine);
        }

        // DELETE: api/GachaMachines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGachaMachine(int id)
        {
            var gachaMachine = await _context.GachaMachines.FindAsync(id);
            if (gachaMachine == null)
            {
                return NotFound();
            }

            _context.GachaMachines.Remove(gachaMachine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GachaMachineExists(int id)
        {
            return _context.GachaMachines.Any(e => e.Id == id);
        }
    }
}
