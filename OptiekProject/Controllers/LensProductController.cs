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
    public class LensProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LensProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LensProduct
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LensProducten.Include(l => l.Sterkte);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LensProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lensProduct = await _context.LensProducten
                .Include(l => l.Sterkte)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (lensProduct == null)
            {
                return NotFound();
            }

            return View(lensProduct);
        }

        // GET: LensProduct/Create
        public IActionResult Create()
        {
            ViewData["SterkteID"] = new SelectList(_context.Sterkten, "SterkteID", "SterkteID");
            return View();
        }

        // POST: LensProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LensType,aantal,ProductID,Naam,Omschrijving,SterkteID,Prijs")] LensProduct lensProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lensProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SterkteID"] = new SelectList(_context.Sterkten, "SterkteID", "SterkteID", lensProduct.SterkteID);
            return View(lensProduct);
        }

        // GET: LensProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lensProduct = await _context.LensProducten.FindAsync(id);
            if (lensProduct == null)
            {
                return NotFound();
            }
            ViewData["SterkteID"] = new SelectList(_context.Sterkten, "SterkteID", "SterkteID", lensProduct.SterkteID);
            return View(lensProduct);
        }

        // POST: LensProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LensType,aantal,ProductID,Naam,Omschrijving,SterkteID,Prijs")] LensProduct lensProduct)
        {
            if (id != lensProduct.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lensProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LensProductExists(lensProduct.ProductID))
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
            ViewData["SterkteID"] = new SelectList(_context.Sterkten, "SterkteID", "SterkteID", lensProduct.SterkteID);
            return View(lensProduct);
        }

        // GET: LensProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lensProduct = await _context.LensProducten
                .Include(l => l.Sterkte)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (lensProduct == null)
            {
                return NotFound();
            }

            return View(lensProduct);
        }

        // POST: LensProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lensProduct = await _context.LensProducten.FindAsync(id);
            _context.LensProducten.Remove(lensProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LensProductExists(int id)
        {
            return _context.LensProducten.Any(e => e.ProductID == id);
        }
    }
}
