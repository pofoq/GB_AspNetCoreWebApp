using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Timesheets.BusinessLayer.Abstractions.Mappers;
using Timesheets.BusinessLayer.Abstractions.Services;
using Timesheets.BusinessLayer.Dto;
using Timesheets.BusinessLayer.Requests;
using Timesheets.DataLayer.Abstractions.Repositories;
using Timesheets.DataLayer.Models;
using System.Text;

namespace Timesheets.BusinessLayer.Services
{
    public class UserService : IUserService
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

        private static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }
    }
}
