using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
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

        // GET: api/GachaMachines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GachaMachine>> GetGachaMachine(int id)
        {
            var gachaMachine = await _context.GachaMachines.FindAsync(id);

            if (gachaMachine == null)
            {
                return NotFound();
            }

            return gachaMachine;
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
