using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceSystemWebData;
using SpaceSystemWebModels;
using SpaceSystemWebServices;

namespace SpaceSystemWeb.Controllers
{
    public class StarsController : Controller
    {
        //private readonly SpaceSystemWebDbContext _context;
        private readonly IStarsService _starsService;

        public StarsController(IStarsService starsService)
        {
            _starsService = starsService;
        }

        // GET: Stars
        public async Task<IActionResult> Index()
        {
            var stars = await _starsService.GetAllAsync();
            return View(stars);
        }

        // GET: Stars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || await _starsService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var star = await _starsService.GetAsync((int)id);
            if (star == null)
            {
                return NotFound();
            }

            return View(star);
        }

        [Authorize(Roles = "Admin")]
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
                await _starsService.AddOrUpdateAsync(star);
                return RedirectToAction(nameof(Index));
            }
            return View(star);
        }

        [Authorize(Roles = "Admin")]
        // GET: Stars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || await _starsService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var star = await _starsService.GetAsync((int)id);
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
                    await _starsService.AddOrUpdateAsync(star);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StarExists(star.Id))
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

        [Authorize(Roles = "Admin")]
        // GET: Stars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await _starsService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var star = await _starsService.GetAsync((int)id);
            if (star == null)
            {
                return NotFound();
            }

            return View(star);
        }

        [Authorize(Roles = "Admin")]
        // POST: Stars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _starsService.GetAllAsync() == null)
            {
                return Problem("Entity set 'SpaceSystemWebDbContext.Stars'  is null.");
            }
            await _starsService.DeleteAsync(id);
            //var star = await _starsService.GetAsync((int)id);
            //if (star != null)
            //{
            //    await _starsService.DeleteAsync(id);
            //}

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> StarExists(int id)
        {
          return await _starsService.ExistsAsync(id);
        }
    }
}
