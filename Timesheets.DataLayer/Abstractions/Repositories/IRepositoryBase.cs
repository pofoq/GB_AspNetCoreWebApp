using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Timesheets.DataLayer.Abstractions.Repositories
{
    public interface IRepositoryBase<TModel, TId>
    {
        Task<TModel> GetByIdAsync(TId id, CancellationToken token);
        Task<IEnumerable<TModel>> GetAllAsync(int count, int page, string searchByName, CancellationToken token);
        Task<TModel> AddAsync(TModel model, CancellationToken token);
        Task<bool> UpdateAsync(TModel model, CancellationToken token);
        Task<bool> DeleteByIdAsync(TId id, CancellationToken token);
    }
}
