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
        public async Task<int> AddOrUpdateAsync(Star s)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Star s)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Star>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Star> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
