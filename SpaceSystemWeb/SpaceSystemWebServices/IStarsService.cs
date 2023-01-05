using SpaceSystemWebModels;

namespace SpaceSystemWebServices
{
    public interface IStarsService
    {
        //Employee has access to all of this as long as not sold
        Task<List<Star>> GetAllAsync();
        Task<Star> GetAsync(int id);
        Task<int> AddOrUpdateAsync(Star s);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(Star s);
        Task<bool> ExistsAsync(int id);
    }
}
