using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gachaAPI.DTO;
using gachaAPI.Models;

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

        // 找出符合機台ID的扭蛋照片
        // GET: api/GachaProducts/GetPicture/{id}
        [HttpGet("GetPicture/{machineId}")]
        public async Task<IActionResult> GetPicture(int machineId)
        {
            var gachaProduct = await _context.GachaProducts
                .Include(gp => gp.Machine)
                .FirstOrDefaultAsync(gp => gp.Machine.Id == machineId);

            if (gachaProduct == null || string.IsNullOrEmpty(gachaProduct.ProductPictureName))
            {
                return NotFound();
            }

            var path = Path.Combine("images", gachaProduct.ProductPictureName);
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var image = System.IO.File.OpenRead(path);
            return File(image, "image/jpeg");
        }

        // 找出所有扭蛋資料(不包含機台照片)
        // GET: api/GachaProducts
        [HttpGet]
        public async Task<IEnumerable<GachaProductDTO>> GetGachaProducts()
        {
            return _context.GachaProducts
                .Include(gp => gp.Machine)
                .Select(GachaProduct => new GachaProductDTO
                {
                    id = GachaProduct.Id,
                    machineName = GachaProduct.Machine.MachineName,
                    productName = GachaProduct.ProductName,
                    machineDescription = GachaProduct.Machine.MachineDescription,
                    price = GachaProduct.Machine.Price,
                    stock = GachaProduct.Stock,
                    productPictureName = GachaProduct.ProductPictureName
                });
        }

        //透過machineId找出其扭蛋資料(含機台照片)
        // GET: api/GachaProducts/machine
        [HttpGet("machine/{machineId}")]
        public async Task<ActionResult<IEnumerable<GachaProductDTObyMachineId>>> GetGachaProductByMachineId(int machineId)
        {
            var gachaProduct = await _context.GachaProducts
                .Include(gp => gp.Machine)
                .Where(gp => gp.Machine.Id == machineId)
                .Select(gpbm => new GachaProductDTObyMachineId
                {
                    machineId = gpbm.Machine.Id,
                    machineName = gpbm.Machine.MachineName,
                    machinePictureName = gpbm.Machine.MachinePictureName,
                    productName = gpbm.ProductName,
                    machineDescription = gpbm.Machine.MachineDescription,
                    price = gpbm.Machine.Price,
                    stock = gpbm.Stock,
                    productPictureName = gpbm.ProductPictureName
                })
                .ToListAsync();

            if (gachaProduct == null)
            {
                return null;
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