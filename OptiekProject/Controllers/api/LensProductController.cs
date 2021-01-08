using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Optiek.Data;
using Project_Optiek.Models;

namespace Project_Optiek.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LensProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LensProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LensProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LensProduct>>> GetLensProducten()
        {
            return await _context.LensProducten.ToListAsync();
        }

        // GET: api/LensProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LensProduct>> GetLensProduct(int id)
        {
            var lensProduct = await _context.LensProducten.FindAsync(id);

            if (lensProduct == null)
            {
                return NotFound();
            }

            return lensProduct;
        }

        // PUT: api/LensProduct/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLensProduct(int id, LensProduct lensProduct)
        {
            if (id != lensProduct.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(lensProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LensProductExists(id))
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

        // POST: api/LensProduct
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LensProduct>> PostLensProduct(LensProduct lensProduct)
        {
            _context.LensProducten.Add(lensProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLensProduct", new { id = lensProduct.ProductID }, lensProduct);
        }

        // DELETE: api/LensProduct/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LensProduct>> DeleteLensProduct(int id)
        {
            var lensProduct = await _context.LensProducten.FindAsync(id);
            if (lensProduct == null)
            {
                return NotFound();
            }

            _context.LensProducten.Remove(lensProduct);
            await _context.SaveChangesAsync();

            return lensProduct;
        }

        private bool LensProductExists(int id)
        {
            return _context.LensProducten.Any(e => e.ProductID == id);
        }
    }
}
