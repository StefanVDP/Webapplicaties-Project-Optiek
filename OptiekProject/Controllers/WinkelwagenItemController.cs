using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Optiek.Data;
using Project_Optiek.Models;
using Project_Optiek.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Project_Optiek.Controllers
{
    [Authorize]
    public class WinkelwagenItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WinkelwagenItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WinkelwagenItem
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WinkelwagenItems.Include(w => w.Gebruiker).Include(w => w.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WinkelwagenItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var winkelwagenItem = await _context.WinkelwagenItems
                .Include(w => w.Gebruiker)
                .Include(w => w.Product)
                .FirstOrDefaultAsync(m => m.WinkelwagenItemID == id);
            if (winkelwagenItem == null)
            {
                return NotFound();
            }

            return View(winkelwagenItem);
        }

        // GET: WinkelwagenItem/Create
        public IActionResult Create()
        {
            ViewData["GebruikerID"] = new SelectList(_context.Gebruikers, "GebruikerID", "GebruikerID");
            ViewData["ProductID"] = new SelectList(_context.Producten, "ProductID", "Discriminator");
            return View();
        }

        // POST: WinkelwagenItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WinkelwagenItemID,GebruikerID,ProductID,Aantal")] WinkelwagenItem winkelwagenItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(winkelwagenItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GebruikerID"] = new SelectList(_context.Gebruikers, "GebruikerID", "GebruikerID", winkelwagenItem.GebruikerID);
            ViewData["ProductID"] = new SelectList(_context.Producten, "ProductID", "Discriminator", winkelwagenItem.ProductID);
            return View(winkelwagenItem);
        }

        // GET: WinkelwagenItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var winkelwagenItem = await _context.WinkelwagenItems.FindAsync(id);
            if (winkelwagenItem == null)
            {
                return NotFound();
            }
            ViewData["GebruikerID"] = new SelectList(_context.Gebruikers, "GebruikerID", "GebruikerID", winkelwagenItem.GebruikerID);
            ViewData["ProductID"] = new SelectList(_context.Producten, "ProductID", "Discriminator", winkelwagenItem.ProductID);
            return View(winkelwagenItem);
        }

        // POST: WinkelwagenItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WinkelwagenItemID,GebruikerID,ProductID,Aantal")] WinkelwagenItem winkelwagenItem)
        {
            if (id != winkelwagenItem.WinkelwagenItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(winkelwagenItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WinkelwagenItemExists(winkelwagenItem.WinkelwagenItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GebruikerID"] = new SelectList(_context.Gebruikers, "GebruikerID", "GebruikerID", winkelwagenItem.GebruikerID);
            ViewData["ProductID"] = new SelectList(_context.Producten, "ProductID", "Discriminator", winkelwagenItem.ProductID);
            return View(winkelwagenItem);
        }

        // GET: WinkelwagenItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var winkelwagenItem = await _context.WinkelwagenItems
                .Include(w => w.Gebruiker)
                .Include(w => w.Product)
                .FirstOrDefaultAsync(m => m.WinkelwagenItemID == id);
            if (winkelwagenItem == null)
            {
                return NotFound();
            }

            return View(winkelwagenItem);
        }

        // POST: WinkelwagenItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var winkelwagenItem = await _context.WinkelwagenItems.FindAsync(id);
            _context.WinkelwagenItems.Remove(winkelwagenItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WinkelwagenItemExists(int id)
        {
            return _context.WinkelwagenItems.Any(e => e.WinkelwagenItemID == id);
        }
    }
}
