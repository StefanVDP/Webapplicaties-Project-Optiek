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
    public class BrilController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrilController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bril
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Brillen.Include(b => b.Sterkte);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bril/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bril = await _context.Brillen
                .Include(b => b.Sterkte)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (bril == null)
            {
                return NotFound();
            }

            return View(bril);
        }

        // GET: Bril/Create
        public IActionResult Create()
        {
            ViewData["SterkteID"] = new SelectList(_context.Sterkten, "SterkteID", "SterkteID");
            return View();
        }

        // POST: Bril/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrilType,ProductID,Naam,Omschrijving,SterkteID,Prijs")] Bril bril)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bril);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SterkteID"] = new SelectList(_context.Sterkten, "SterkteID", "SterkteID", bril.SterkteID);
            return View(bril);
        }

        // GET: Bril/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bril = await _context.Brillen.FindAsync(id);
            if (bril == null)
            {
                return NotFound();
            }
            ViewData["SterkteID"] = new SelectList(_context.Sterkten, "SterkteID", "SterkteID", bril.SterkteID);
            return View(bril);
        }

        // POST: Bril/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrilType,ProductID,Naam,Omschrijving,SterkteID,Prijs")] Bril bril)
        {
            if (id != bril.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bril);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrilExists(bril.ProductID))
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
            ViewData["SterkteID"] = new SelectList(_context.Sterkten, "SterkteID", "SterkteID", bril.SterkteID);
            return View(bril);
        }

        // GET: Bril/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bril = await _context.Brillen
                .Include(b => b.Sterkte)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (bril == null)
            {
                return NotFound();
            }

            return View(bril);
        }

        // POST: Bril/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bril = await _context.Brillen.FindAsync(id);
            _context.Brillen.Remove(bril);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrilExists(int id)
        {
            return _context.Brillen.Any(e => e.ProductID == id);
        }
    }
}
