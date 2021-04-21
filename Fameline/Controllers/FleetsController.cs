using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fameline.Lib.DAL;
using Fameline.Lib.Models;

namespace Fameline.Controllers
{
    public class FleetsController : Controller
    {
        private readonly FamelineContext _context;

        public FleetsController(FamelineContext context)
        {
            _context = context;
        }

        // GET: Fleets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fleets.ToListAsync());
        }

        // GET: Fleets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fleet = await _context.Fleets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fleet == null)
            {
                return NotFound();
            }

            return View(fleet);
        }

        // GET: Fleets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fleets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Fleet fleet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fleet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fleet);
        }

        // GET: Fleets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fleet = await _context.Fleets.FindAsync(id);
            if (fleet == null)
            {
                return NotFound();
            }
            return View(fleet);
        }

        // POST: Fleets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Fleet fleet)
        {
            if (id != fleet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fleet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FleetExists(fleet.Id))
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
            return View(fleet);
        }

        // GET: Fleets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fleet = await _context.Fleets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fleet == null)
            {
                return NotFound();
            }

            return View(fleet);
        }

        // POST: Fleets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fleet = await _context.Fleets.FindAsync(id);
            _context.Fleets.Remove(fleet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FleetExists(int id)
        {
            return _context.Fleets.Any(e => e.Id == id);
        }
    }
}
