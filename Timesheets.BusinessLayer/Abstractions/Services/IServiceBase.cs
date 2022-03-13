using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Timesheets.BusinessLayer.Abstractions.Services
{
    public interface IServiceBase<TDto, TId, TAddRequest>
    {
        Task<TDto> GetByIdAsync(TId id, CancellationToken token);
        Task<IEnumerable<TDto>> GetAllAsync(int count, int page, string searchByName, CancellationToken token);
        Task<TDto> AddAsync(TAddRequest dto, CancellationToken token);
        Task<bool> UpdateAsync(TDto dto, CancellationToken token);
        Task<bool> DeleteByIdAsync(TId id, CancellationToken token);
    }
}
