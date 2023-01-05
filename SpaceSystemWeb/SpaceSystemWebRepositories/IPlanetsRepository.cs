using SpaceSystemWebModels;

namespace SpaceSystemWebRepositories
{
    public interface IPlanetsRepository
    {
        Task<List<Planet>> GetAllAsync();
        Task<Planet> GetAsync(int id);
        Task<int> AddOrUpdateAsync(Planet p);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(Planet p);
        Task<bool> ExistsAsync(int id);
    }
}