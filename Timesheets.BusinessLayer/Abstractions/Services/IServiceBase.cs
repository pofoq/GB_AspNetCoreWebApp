using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheets.BusinessLayer.Abstractions.Services
{
    public interface IServiceBase<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(int count, int page, string searchByName);
        Task<T> AddAsync(T dto);
        Task<bool> UpdateAsync(T dto);
        Task<bool> DeleteByIdAsync(int id);

    }
}
