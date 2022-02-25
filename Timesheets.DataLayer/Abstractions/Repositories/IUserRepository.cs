using System.Threading;
using System.Threading.Tasks;
using Timesheets.DataLayer.Models;

namespace Timesheets.DataLayer.Abstractions.Repositories
{
    public interface IUserRepository : IRepositoryBase<User, int>
    {
        Task<User> GetByUsernameAsync(string username, byte[] passwordHash, CancellationToken token);
        Task<User> GetByTokenAsync(string refreshToken, CancellationToken token);
    }
}
