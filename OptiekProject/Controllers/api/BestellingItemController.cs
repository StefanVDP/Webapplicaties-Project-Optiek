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
    public class BestellingItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BestellingItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BestellingItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BestellingItem>>> GetbestellingItems()
        {
            return await _context.bestellingItems.ToListAsync();
        }

        // GET: api/BestellingItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BestellingItem>> GetBestellingItem(int id)
        {
            var bestellingItem = await _context.bestellingItems.FindAsync(id);

            if (bestellingItem == null)
            {
                return NotFound();
            }

            return bestellingItem;
        }

        // PUT: api/BestellingItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBestellingItem(int id, BestellingItem bestellingItem)
        {
            if (id != bestellingItem.BestellingItemID)
            {
                return BadRequest();
            }

            _context.Entry(bestellingItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BestellingItemExists(id))
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

        // POST: api/BestellingItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BestellingItem>> PostBestellingItem(BestellingItem bestellingItem)
        {
            _context.bestellingItems.Add(bestellingItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBestellingItem", new { id = bestellingItem.BestellingItemID }, bestellingItem);
        }

        // DELETE: api/BestellingItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BestellingItem>> DeleteBestellingItem(int id)
        {
            var bestellingItem = await _context.bestellingItems.FindAsync(id);
            if (bestellingItem == null)
            {
                return NotFound();
            }

            _context.bestellingItems.Remove(bestellingItem);
            await _context.SaveChangesAsync();

            return bestellingItem;
        }

        private bool BestellingItemExists(int id)
        {
            return _context.bestellingItems.Any(e => e.BestellingItemID == id);
        }
    }
}
