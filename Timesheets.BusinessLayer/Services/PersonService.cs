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

        public async Task<PersonDto> AddAsync(AddPersonRequest request, CancellationToken token)
        {
            var personDto = new PersonDto
            {
                Age = request.Age,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Company = request.Company,
                Email = request.Email,
            };

            var model = await _repository.AddAsync(_mapper.Map(personDto), token);
            if (model == null)
            {
                return new PersonDto();
            }

            return _mapper.Map(model);
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteByIdAsync(id, token);
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync(int count, int page, string searchByName, CancellationToken token)
        {
            var persons = await _repository.GetAllAsync(count, page, searchByName, token);
            return _mapper.Map(persons);
        }

        public async Task<PersonDto> GetByIdAsync(int id, CancellationToken token)
        {
            var model = await _repository.GetByIdAsync(id, token);
            if (model == null)
            {
                return new PersonDto();
            }
            return _mapper.Map(model);
        }

        public Task<bool> UpdateAsync(PersonDto dto, CancellationToken token)
        {
            return _repository.UpdateAsync(_mapper.Map(dto), token);
        }
    }
}