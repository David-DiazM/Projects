using SpaceSystemWebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSystemWebServices
{
    public class StarsService : IStarsService
    {
        public Task<int> AddOrUpdateAsync(Star s)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Star s)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Star>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Star> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
