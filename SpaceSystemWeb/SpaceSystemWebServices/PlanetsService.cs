using SpaceSystemWebModels;
using SpaceSystemWebRepositories;

namespace SpaceSystemWebServices
{
    public class PlanetsService : IPlanetsService
    {
        private IPlanetsRepository _planetsRepository;

        public PlanetsService(IPlanetsRepository planetsRepository)
        {
            _planetsRepository = planetsRepository;
        }

        public async Task<List<Planet>> GetAllAsync()
        {
            var data =  await _planetsRepository.GetAllAsync();
            return data;
        }

        public async Task<Planet> GetAsync(int id)
        {
            return await _planetsRepository.GetAsync(id);
        }

        public async Task<int> AddOrUpdateAsync(Planet p)
        {
            return await _planetsRepository.AddOrUpdateAsync(p);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _planetsRepository.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(Planet p)
        {
            return await _planetsRepository.DeleteAsync(p);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _planetsRepository.ExistsAsync(id);
        }

        public async Task<List<Planet>> GetAllCustomerAsync()
        {
            var data = await _planetsRepository.GetAllAsync();
            return data;
        }

        public async Task<Planet> GetCustomerAsync(int id)
        {
            return await _planetsRepository.GetAsync(id);
        }
    }
}
