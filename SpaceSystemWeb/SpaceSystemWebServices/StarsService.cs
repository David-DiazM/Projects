using SpaceSystemWebModels;
using SpaceSystemWebRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSystemWebServices
{
    public class StarsService : IStarsService
    {
        private IStarsRepository _starsRepository;

        public StarsService(IStarsRepository starsRepository)
        {
            _starsRepository = starsRepository;
        }

        public async Task<List<Star>> GetAllAsync()
        {
            var data = await _starsRepository.GetAllAsync();
            return data;
        }

        public async Task<Star> GetAsync(int id)
        {
            return await _starsRepository.GetAsync(id);
        }

        public async Task<int> AddOrUpdateAsync(Star s)
        {
            return await _starsRepository.AddOrUpdateAsync(s);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _starsRepository.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(Star s)
        {
            return await _starsRepository.DeleteAsync(s);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _starsRepository.ExistsAsync(id);
        }

        public async Task<List<Star>> GetAllCustomerAsync()
        {
            var data = await _starsRepository.GetAllAsync();
            return data;
        }

        public async Task<Star> GetCustomerAsync(int id)
        {
            return await _starsRepository.GetAsync(id);
        }
    }
}
