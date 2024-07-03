using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using szAPI.Models;

namespace szAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GachaProductsController : ControllerBase
    {
        private readonly gachaContext _context;

        public GachaProductsController(gachaContext context)
        {
            _context = context;
        }

        // GET: api/GachaProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GachaProduct>>> GetGachaProducts()
        {
            return await _context.GachaProducts.ToListAsync();
        }

        // GET: api/GachaProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GachaProduct>> GetGachaProduct(int id)
        {
            var gachaProduct = await _context.GachaProducts.FindAsync(id);

            if (gachaProduct == null)
            {
                return NotFound();
            }

            return gachaProduct;
        }

        // PUT: api/GachaProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGachaProduct(int id, GachaProduct gachaProduct)
        {
            if (id != gachaProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(gachaProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GachaProductExists(id))
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

        // POST: api/GachaProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GachaProduct>> PostGachaProduct(GachaProduct gachaProduct)
        {
            _context.GachaProducts.Add(gachaProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGachaProduct", new { id = gachaProduct.Id }, gachaProduct);
        }

        // DELETE: api/GachaProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGachaProduct(int id)
        {
            var gachaProduct = await _context.GachaProducts.FindAsync(id);
            if (gachaProduct == null)
            {
                return NotFound();
            }

            _context.GachaProducts.Remove(gachaProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GachaProductExists(int id)
        {
            return _context.GachaProducts.Any(e => e.Id == id);
        }
    }
}
