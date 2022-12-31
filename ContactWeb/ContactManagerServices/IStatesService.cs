using ContactWebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerServices
{
    public interface IStatesService
    {
        Task<List<State>> GetAllAsync();
        Task<State> GetAsync(int id);
        Task<int> AddOrUpdateAsync(State state);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(State state);
        Task<bool> ExistsAsync(int id);
    }
}
