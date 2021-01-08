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
    public class SterkteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SterkteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sterkte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sterkte>>> GetSterkten()
        {
            return await _context.Sterkten.ToListAsync();
        }

        // GET: api/Sterkte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sterkte>> GetSterkte(int id)
        {
            var sterkte = await _context.Sterkten.FindAsync(id);

            if (sterkte == null)
            {
                return NotFound();
            }

            return sterkte;
        }

        // PUT: api/Sterkte/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSterkte(int id, Sterkte sterkte)
        {
            if (id != sterkte.SterkteID)
            {
                return BadRequest();
            }

            _context.Entry(sterkte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SterkteExists(id))
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

        // POST: api/Sterkte
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sterkte>> PostSterkte(Sterkte sterkte)
        {
            _context.Sterkten.Add(sterkte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSterkte", new { id = sterkte.SterkteID }, sterkte);
        }

        // DELETE: api/Sterkte/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sterkte>> DeleteSterkte(int id)
        {
            var sterkte = await _context.Sterkten.FindAsync(id);
            if (sterkte == null)
            {
                return NotFound();
            }

            _context.Sterkten.Remove(sterkte);
            await _context.SaveChangesAsync();

            return sterkte;
        }

        private bool SterkteExists(int id)
        {
            return _context.Sterkten.Any(e => e.SterkteID == id);
        }
    }
}
