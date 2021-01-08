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
    public class SterkteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SterkteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sterkte
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ListSterkteViewModel viewModel = new ListSterkteViewModel();
            return View(viewModel);
        }

        // GET: Sterkte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sterkte = await _context.Sterkten
                .FirstOrDefaultAsync(m => m.SterkteID == id);
            if (sterkte == null)
            {
                return NotFound();
            }

            return View(sterkte);
        }

        // GET: Sterkte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sterkte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SterkteID,sterkte")] Sterkte sterkte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sterkte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sterkte);
        }

        // GET: Sterkte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sterkte = await _context.Sterkten.FindAsync(id);
            if (sterkte == null)
            {
                return NotFound();
            }
            return View(sterkte);
        }

        // POST: Sterkte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SterkteID,sterkte")] Sterkte sterkte)
        {
            if (id != sterkte.SterkteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sterkte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SterkteExists(sterkte.SterkteID))
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
            return View(sterkte);
        }

        // GET: Sterkte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sterkte = await _context.Sterkten
                .FirstOrDefaultAsync(m => m.SterkteID == id);
            if (sterkte == null)
            {
                return NotFound();
            }

            return View(sterkte);
        }

        // POST: Sterkte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sterkte = await _context.Sterkten.FindAsync(id);
            _context.Sterkten.Remove(sterkte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SterkteExists(int id)
        {
            return _context.Sterkten.Any(e => e.SterkteID == id);
        }
    }
}
