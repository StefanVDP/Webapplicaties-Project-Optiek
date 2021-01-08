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
    public class WinkelwagenItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WinkelwagenItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WinkelwagenItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WinkelwagenItem>>> GetWinkelwagenItems()
        {
            return await _context.WinkelwagenItems.ToListAsync();
        }

        // GET: api/WinkelwagenItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WinkelwagenItem>> GetWinkelwagenItem(int id)
        {
            var winkelwagenItem = await _context.WinkelwagenItems.FindAsync(id);

            if (winkelwagenItem == null)
            {
                return NotFound();
            }

            return winkelwagenItem;
        }

        // PUT: api/WinkelwagenItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWinkelwagenItem(int id, WinkelwagenItem winkelwagenItem)
        {
            if (id != winkelwagenItem.WinkelwagenItemID)
            {
                return BadRequest();
            }

            _context.Entry(winkelwagenItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinkelwagenItemExists(id))
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

        // POST: api/WinkelwagenItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WinkelwagenItem>> PostWinkelwagenItem(WinkelwagenItem winkelwagenItem)
        {
            _context.WinkelwagenItems.Add(winkelwagenItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinkelwagenItem", new { id = winkelwagenItem.WinkelwagenItemID }, winkelwagenItem);
        }

        // DELETE: api/WinkelwagenItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WinkelwagenItem>> DeleteWinkelwagenItem(int id)
        {
            var winkelwagenItem = await _context.WinkelwagenItems.FindAsync(id);
            if (winkelwagenItem == null)
            {
                return NotFound();
            }

            _context.WinkelwagenItems.Remove(winkelwagenItem);
            await _context.SaveChangesAsync();

            return winkelwagenItem;
        }

        private bool WinkelwagenItemExists(int id)
        {
            return _context.WinkelwagenItems.Any(e => e.WinkelwagenItemID == id);
        }
    }
}
