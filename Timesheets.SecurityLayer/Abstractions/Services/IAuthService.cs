using System.Threading;
using System.Threading.Tasks;
using Timesheets.SecurityLayer.Dto;

namespace Timesheets.SecurityLayer.Abstractions.Services
{
    public interface IAuthService
    {
        Task<TokenResponse> AuthenticateAsync(string username, string password, CancellationToken token);
        Task<TokenResponse> RefreshToken(string refreshToken, CancellationToken token);
    }
}
