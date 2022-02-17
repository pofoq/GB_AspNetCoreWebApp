using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.BusinessLayer.Abstractions.Mappers;
using Timesheets.BusinessLayer.Abstractions.Services;
using Timesheets.BusinessLayer.Dto;
using Timesheets.DataLayer.Abstractions.Repositories;

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

        public async Task<UserDto> AddAsync(UserDto dto, CancellationToken token)
        {
            var model = _mapper.Map(dto);
            model = await _repository.AddAsync(model, token);
            dto = _mapper.Map(model);
            return dto;
        }

        public async Task<bool> DeleteAsync(UserDto dto, CancellationToken token)
        {
            var model = _mapper.Map(dto);
            return await _repository.DeleteAsync(model, token);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(int count, int page, string searchByName, CancellationToken token)
        {
            var models = await _repository.GetAllAsync(count, page, searchByName, token);
            var dtos = _mapper.Map(models);
            return dtos;
        }

        public async Task<UserDto> GetByIdAsync(Guid id, CancellationToken token)
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
    }
}
