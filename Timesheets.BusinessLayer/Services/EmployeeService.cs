using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.BusinessLayer.Abstractions.Mappers;
using Timesheets.BusinessLayer.Abstractions.Services;
using Timesheets.BusinessLayer.Dto;
using Timesheets.BusinessLayer.Requests;
using Timesheets.DataLayer.Abstractions.Repositories;
using Timesheets.DataLayer.Models;

namespace Timesheets.BusinessLayer.Services
{
    public sealed class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IEmployeeMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IEmployeeMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> AddAsync(AddEmployeeRequest request, CancellationToken token)
        {
            var model = new Employee
            {
                IsDeleted = request.IsDeleted,
                UserId = request.UserId,
            };
            model = await _repository.AddAsync(model, token);
            var dto = _mapper.Map(model);
            return dto;
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteByIdAsync(id, token);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(int count, int page, string searchByName, CancellationToken token)
        {
            var models = await _repository.GetAllAsync(count, page, searchByName, token);
            var dtos = _mapper.Map(models);
            return dtos;
        }

        public async Task<EmployeeDto> GetByIdAsync(int id, CancellationToken token)
        {
            var model = await _repository.GetByIdAsync(id, token);
            var dto = _mapper.Map(model);
            return dto;
        }

        public async Task<bool> UpdateAsync(EmployeeDto dto, CancellationToken token)
        {
            var model = _mapper.Map(dto);
            return await _repository.UpdateAsync(model, token);
        }
    }
}
