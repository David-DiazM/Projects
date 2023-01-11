using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSystemWeb.Data;
using SpaceSystemWebModels;
using SpaceSystemWebServices;

namespace SpaceSystemWeb.Controllers
{
    public class PlanetsController : Controller
    {
        //private readonly SpaceSystemWebDbContext _context;
        private readonly IPlanetsService _planetsService;

        public PlanetsController(IPlanetsService planetsService)
        {
            _planetsService = planetsService;
        }

        // GET: Planets
        public async Task<IActionResult> Index()
        {
            var planets = await _planetsService.GetAllAsync();
            return View(planets);
        }

        // GET: Planets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _planetsService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var planet = await _planetsService.GetAsync((int)id);
            if (planet == null)
            {
                return NotFound();
            }

            return View(planet);
        }

        [Authorize(Roles = UserRolesService.ADMIN_ROLE_NAME)]
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
                await _planetsService.AddOrUpdateAsync(planet);
                return RedirectToAction(nameof(Index));
            }
            return View(planet);
        }

        [Authorize(Roles = "Admin")]
        // GET: Planets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || await _planetsService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var planet = await _planetsService.GetAsync((int)id);
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
                    await _planetsService.AddOrUpdateAsync(planet);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PlanetExists(planet.Id))
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

        [Authorize(Roles = "Admin")]
        // GET: Planets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await _planetsService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var planet = await _planetsService.GetAsync((int)id);
            if (planet == null)
            {
                return NotFound();
            }

            return View(planet);
        }

        [Authorize(Roles = "Admin")]
        // POST: Planets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _planetsService.GetAllAsync() == null)
            {
                return Problem("Entity set 'SpaceSystemWebDbContext.Planets'  is null.");
            }
            await _planetsService.DeleteAsync(id);
            //var planet = await _planetsService.GetAsync((int)id);
            //if (planet != null)
            //{
            //   await _planetsService.DeleteAsync(id);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PlanetExists(int id)
        {
          return await _planetsService.ExistsAsync(id);
        }
    }
}
