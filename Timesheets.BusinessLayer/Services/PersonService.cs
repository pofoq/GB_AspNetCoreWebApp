using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.BusinessLayer.Abstractions.Services;
using Timesheets.BusinessLayer.Dto;
using Timesheets.DataLayer.Abstractions.Repositories;

namespace Timesheets.BusinessLayer.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> AddAsync(PersonDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(PersonDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync(int count, int page, string searchByName)
        {
            var persons = await _repository.GetAllAsync(count, page, searchByName);
            return Mapper.Map(persons);
        }

        public async Task<PersonDto> GetByIdAsync(int id)
        {
            var person = await _repository.GetByIdAsync(id);
            return Mapper.Map(person);
        }

        public Task<bool> UpdateAsync(PersonDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
