using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.BusinessLayer.Abstractions.Mappers;
using Timesheets.BusinessLayer.Abstractions.Services;
using Timesheets.BusinessLayer.Dto;
using Timesheets.BusinessLayer.Requests;
using Timesheets.DataLayer.Abstractions.Repositories;

namespace Timesheets.BusinessLayer.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IPersonMapper _mapper;

        public PersonService(IPersonRepository repository, IPersonMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PersonDto> AddAsync(AddPersonRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(PersonDto dto, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync(int count, int page, string searchByName, CancellationToken token)
        {
            var persons = await _repository.GetAllAsync(count, page, searchByName, token);
            return _mapper.Map(persons);
        }

        public async Task<PersonDto> GetByIdAsync(int id, CancellationToken token)
        {
            var model = await _repository.GetByIdAsync(id, token);
            return _mapper.Map(model);
        }

        public Task<bool> UpdateAsync(PersonDto dto, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
