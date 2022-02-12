using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheets.DataLayer.Abstractions.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(int count, int page, string searchByName);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
