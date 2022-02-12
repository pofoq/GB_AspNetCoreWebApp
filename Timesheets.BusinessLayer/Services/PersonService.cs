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
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonDto> AddAsync(PersonDto dto)
        {
            var model = await _repository.AddAsync(Mapper.Map(dto));
            return Mapper.Map(model);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync(int count, int page, string searchByName)
        {
            var persons = await _repository.GetAllAsync(count, page, searchByName);
            return Mapper.Map(persons);
        }

        public async Task<PersonDto> GetByIdAsync(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            if (model == null)
            {
                return new PersonDto();
            }
            return Mapper.Map(model);
        }

        public Task<bool> UpdateAsync(PersonDto dto)
        {
            return _repository.UpdateAsync(Mapper.Map(dto));
        }
    }
}
