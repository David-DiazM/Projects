using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpaceSystemWebData;
using SpaceSystemWebModels;

namespace SpaceSystemWeb.Controllers
{
    public class PlanetsController : Controller
    {
        private readonly SpaceSystemWebDbContext _context;

        public PlanetsController(SpaceSystemWebDbContext context)
        {
            _context = context;
        }

        // GET: Planets
        public async Task<IActionResult> Index()
        {
              return _context.Planets != null ? 
                          View(await _context.Planets.ToListAsync()) :
                          Problem("Entity set 'SpaceSystemWebDbContext.Planets'  is null.");
        }

        // GET: Planets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Planets == null)
            {
                return NotFound();
            }

            var planet = await _context.Planets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planet == null)
            {
                return NotFound();
            }

            return View(planet);
        }

        // GET: Planets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoughtId,Name,OrbitInDays,GravitationalPull,Moons,CustomerId")] Planet planet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planet);
        }

        // GET: Planets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Planets == null)
            {
                return NotFound();
            }

            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return NotFound();
            }
            return View(planet);
        }

        // POST: Planets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoughtId,Name,OrbitInDays,GravitationalPull,Moons,CustomerId")] Planet planet)
        {
            if (id != planet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanetExists(planet.Id))
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
            return View(planet);
        }

        // GET: Planets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Planets == null)
            {
                return NotFound();
            }

            var planet = await _context.Planets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planet == null)
            {
                return NotFound();
            }

            return View(planet);
        }

        // POST: Planets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Planets == null)
            {
                return Problem("Entity set 'SpaceSystemWebDbContext.Planets'  is null.");
            }
            var planet = await _context.Planets.FindAsync(id);
            if (planet != null)
            {
                _context.Planets.Remove(planet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanetExists(int id)
        {
          return (_context.Planets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
