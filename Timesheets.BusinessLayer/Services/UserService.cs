using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.BusinessLayer.Abstractions.Mappers;
using Timesheets.BusinessLayer.Abstractions.Services;
using Timesheets.BusinessLayer.Dto;
using Timesheets.BusinessLayer.Requests;
using Timesheets.DataLayer.Abstractions.Repositories;
using Timesheets.DataLayer.Models;
using Timesheets.SecurityLayer.Dto;
using Timesheets.SecurityLayer.Abstractions.Services;

namespace Timesheets.BusinessLayer.Services
{
    public sealed class UserService : SecurityService, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserMapper _mapper;

        public UserService(IUserRepository repository, IUserMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> AddAsync(AddUserRequest request, CancellationToken token)
        {
            var model = new User
            {
                PasswordHash = GetPasswordHash(request.Password),
                Role = request.Role,
                Username = request.Username,
            };
            model = await _repository.AddAsync(model, token);
            var dto = _mapper.Map(model);
            return dto;
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteByIdAsync(id, token);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(int count, int page, string searchByName, CancellationToken token)
        {
            var models = await _repository.GetAllAsync(count, page, searchByName, token);
            var dtos = _mapper.Map(models);
            return dtos;
        }

        public async Task<UserDto> GetByIdAsync(int id, CancellationToken token)
        {
            var model = await _repository.GetByIdAsync(id, token);
            var dto = _mapper.Map(model);
            return dto;
        }

        public async Task<bool> UpdateAsync(UserDto dto, CancellationToken token)
        {
            var model = _mapper.Map(dto);
            return await _repository.UpdateAsync(model, token);
        }

        public async Task<TokenResponse> AuthenticateAsync(string username, string password, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            var user = await _repository.GetByUsernameAsync(username, GetPasswordHash(password), token);

            if (user is null)
            {
                return null;
            }

            return await UpdateToken(user, token);
        }

        public async Task<TokenResponse> RefreshToken(string refreshToken, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(refreshToken) || string.IsNullOrWhiteSpace(refreshToken))
            {
                return null;
            }

            var user = await _repository.GetByTokenAsync(refreshToken, token);

            if (user is null)
            {
                return null;
            }

            var oldToken = new RefreshToken { Token = user.RefreshToken, Expires = user.Expires };

            if (oldToken.IsExpired)
            {
                return null;
            }

            return await UpdateToken(user, token);
        }

        private async Task<TokenResponse> UpdateToken(User user, CancellationToken token)
        {
            var refreshToken = GenerateRefreshToken(user.Id, IUserService.AuthKey);
            var jwtToken = GenerateJwtToken(user.Id, IUserService.AuthKey, 5);

            var response = new TokenResponse
            {
                AccessToken = jwtToken,
                RefreshToken = refreshToken.Token
            };

            user.RefreshToken = refreshToken.Token;
            user.Expires = refreshToken.Expires;

            if (await _repository.UpdateAsync(user, token))
            {
                return response;
            }

            return null;
        }
    }
}
