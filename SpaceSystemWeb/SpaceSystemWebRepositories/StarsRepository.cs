using Microsoft.EntityFrameworkCore;
using SpaceSystemWebData;
using SpaceSystemWebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSystemWebRepositories
{
    public class StarsRepository : IStarsRepository
    {
        private readonly SpaceSystemWebDbContext _context;

        public StarsRepository(SpaceSystemWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Star>> GetAllAsync()
        {
            var stars = await _context.Stars.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
            return stars;
        }

        public async Task<Star> GetAsync(int id)
        {
            var star = await _context.Stars.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return star;
        }

        public async Task<int> AddOrUpdateAsync(Star s)
        {
            if (s.Id > 0)
            {
                return await Update(s);
            }
            return await Add(s);
        }

        private async Task<int> Add(Star s)
        {
            await _context.Stars.AddAsync(s);
            await _context.SaveChangesAsync();
            return s.Id;
        }

        private async Task<int> Update(Star s)
        {
            var existingStar = await _context.Stars.SingleOrDefaultAsync(x => x.Id == s.Id);
            if (existingStar is null) throw new Exception("Star not found");

            existingStar.BoughtId = s.BoughtId;
            existingStar.Name = s.Name;
            existingStar.Brightness = s.Brightness;
            existingStar.Temperature = s.Temperature;

            await _context.SaveChangesAsync();
            return s.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var existingStar = await _context.Stars.SingleOrDefaultAsync(x => x.Id == id);
            if (existingStar is null) throw new Exception("Could not delete star due to unable to find matching star");

            _context.Stars.Remove(existingStar);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<int> DeleteAsync(Star s)
        {
            return await DeleteAsync(s.Id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Stars.AsNoTracking().AnyAsync(x => x.Id == id);
        }
    }
}
