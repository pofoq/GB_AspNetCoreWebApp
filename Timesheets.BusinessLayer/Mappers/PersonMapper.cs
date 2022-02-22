using System.Collections.Generic;
using System.Linq;
using Timesheets.BusinessLayer.Abstractions.Mappers;
using Timesheets.BusinessLayer.Dto;
using Timesheets.DataLayer.Models;

namespace Timesheets.BusinessLayer.Mappers
{
    public class PersonMapper : IPersonMapper
    {
        public PersonDto Map(Person model) => new()
        {
            Id = model.Id,
            Age = model.Age,
            Company = model.Company,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
        };

        public IEnumerable<PersonDto> Map(IEnumerable<Person> models)
        {
            foreach (var model in models)
            {
                yield return new PersonDto
                {
                    Id = model.Id,
                    Age = model.Age,
                    Company = model.Company,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
            }
        }

        public Person Map(PersonDto dto) => new()
        {
            Id = dto.Id,
            Age = dto.Age,
            Company = dto.Company,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
        };

        public IEnumerable<Person> Map(IEnumerable<PersonDto> dtos)
        {
            return dtos.Select(x => new Person()
            {
                Id = x.Id,
                Age = x.Age,
                Company = x.Company,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            });
        }
    }
}
