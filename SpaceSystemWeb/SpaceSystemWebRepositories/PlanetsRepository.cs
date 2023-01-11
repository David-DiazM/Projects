using Microsoft.EntityFrameworkCore;
using SpaceSystemWebData;
using SpaceSystemWebModels;

namespace SpaceSystemWebRepositories
{
    public class PlanetsRepository : IPlanetsRepository
    {
        private readonly SpaceSystemWebDbContext _context;

        public PlanetsRepository(SpaceSystemWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Planet>> GetAllAsync()
        {
            var planets = await _context.Planets.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
            return planets;
        }

        public async Task<Planet> GetAsync(int id)
        {
            var planet = await _context.Planets.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return planet;
        }

        public async Task<int> AddOrUpdateAsync(Planet p)
        {
            if (p.Id > 0)
            {
                return await Update(p);
            }
            return await Add(p);
        }

        private async Task<int> Add(Planet p)
        {
            await _context.Planets.AddAsync(p);
            await _context.SaveChangesAsync();
            return p.Id;
        }

        private async Task<int> Update(Planet p)
        {
            var existingPlanet = await _context.Planets.SingleOrDefaultAsync(x => x.Id == p.Id);
            if (existingPlanet is null) throw new Exception("Planet not found");

            existingPlanet.BoughtId = p.BoughtId;
            existingPlanet.Name = p.Name;
            existingPlanet.OrbitInDays= p.OrbitInDays;
            existingPlanet.GravitationalPull = p.GravitationalPull;
            existingPlanet.Moons= p.Moons;

            await _context.SaveChangesAsync();
            return p.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var existingPlanet = await _context.Planets.SingleOrDefaultAsync(x => x.Id == id);
            if (existingPlanet is null) throw new Exception("Could not delete planet due to unable to find matching planet");

            _context.Planets.Remove(existingPlanet);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<int> DeleteAsync(Planet p)
        {
            return await DeleteAsync(p.Id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Planets.AsNoTracking().AnyAsync(x => x.Id == id);
        }
    }
}
