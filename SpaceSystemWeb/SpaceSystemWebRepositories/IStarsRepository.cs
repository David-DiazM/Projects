using SpaceSystemWebModels;

namespace SpaceSystemWebRepositories
{
    public interface IStarsRepository
    {
        Task<List<Star>> GetAllAsync();
        Task<Star> GetAsync(int id);
        Task<int> AddOrUpdateAsync(Star s);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(Star s);
        Task<bool> ExistsAsync(int id);
    }
}
