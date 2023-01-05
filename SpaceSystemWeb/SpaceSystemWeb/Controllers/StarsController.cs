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
    public class StarsController : Controller
    {
        private readonly SpaceSystemWebDbContext _context;

        public StarsController(SpaceSystemWebDbContext context)
        {
            _context = context;
        }

        // GET: Stars
        public async Task<IActionResult> Index()
        {
              return _context.Stars != null ? 
                          View(await _context.Stars.ToListAsync()) :
                          Problem("Entity set 'SpaceSystemWebDbContext.Stars'  is null.");
        }

        // GET: Stars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stars == null)
            {
                return NotFound();
            }

            var star = await _context.Stars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (star == null)
            {
                return NotFound();
            }

            return View(star);
        }

        // GET: Stars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoughtId,Name,Temperature,Brightness,CustomerId")] Star star)
        {
            if (ModelState.IsValid)
            {
                _context.Add(star);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(star);
        }

        // GET: Stars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stars == null)
            {
                return NotFound();
            }

            var star = await _context.Stars.FindAsync(id);
            if (star == null)
            {
                return NotFound();
            }
            return View(star);
        }

        // POST: Stars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoughtId,Name,Temperature,Brightness,CustomerId")] Star star)
        {
            if (id != star.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(star);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarExists(star.Id))
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
            return View(star);
        }

        // GET: Stars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stars == null)
            {
                return NotFound();
            }

            var star = await _context.Stars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (star == null)
            {
                return NotFound();
            }

            return View(star);
        }

        // POST: Stars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stars == null)
            {
                return Problem("Entity set 'SpaceSystemWebDbContext.Stars'  is null.");
            }
            var star = await _context.Stars.FindAsync(id);
            if (star != null)
            {
                _context.Stars.Remove(star);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarExists(int id)
        {
          return (_context.Stars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
