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
    public class BrilController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BrilController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bril
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bril>>> GetBrillen()
        {
            return await _context.Brillen.ToListAsync();
        }

        // GET: api/Bril/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bril>> GetBril(int id)
        {
            var bril = await _context.Brillen.FindAsync(id);

            if (bril == null)
            {
                return NotFound();
            }

            return bril;
        }

        // PUT: api/Bril/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBril(int id, Bril bril)
        {
            if (id != bril.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(bril).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrilExists(id))
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

        // POST: api/Bril
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bril>> PostBril(Bril bril)
        {
            _context.Brillen.Add(bril);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBril", new { id = bril.ProductID }, bril);
        }

        // DELETE: api/Bril/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bril>> DeleteBril(int id)
        {
            var bril = await _context.Brillen.FindAsync(id);
            if (bril == null)
            {
                return NotFound();
            }

            _context.Brillen.Remove(bril);
            await _context.SaveChangesAsync();

            return bril;
        }

        private bool BrilExists(int id)
        {
            return _context.Brillen.Any(e => e.ProductID == id);
        }
    }
}
