using SpaceSystemWebModels;

namespace SpaceSystemWebServices
{
    public interface IPlanetsService
    {
        //Employee has access to all of this as long as not sold
        Task<List<Planet>> GetAllAsync();
        Task<Planet> GetAsync(int id);
        Task<int> AddOrUpdateAsync(Planet p);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(Planet p);
        Task<bool> ExistsAsync(int id);
    }
}