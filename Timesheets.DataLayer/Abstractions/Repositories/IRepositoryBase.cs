using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheets.DataLayer.Abstractions.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(int count, int page, string searchByName);
        Task<T> AddAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteByIdAsync(int id);
    }
}
