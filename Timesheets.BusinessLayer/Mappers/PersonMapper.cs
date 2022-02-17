using System.Collections.Generic;
using Timesheets.BusinessLayer.Abstractions.Mappers;
using Timesheets.BusinessLayer.Dto;
using Timesheets.DataLayer.Models;

namespace Timesheets.BusinessLayer.Mappers
{
    public class PersonMapper : IPersonMapper
    {
        public PersonDto Map(Person person) => new()
        {
            Id = person.Id,
            Age = person.Age,
            Company = person.Company,
            Email = person.Email,
            FirstName = person.FirstName,
            LastName = person.LastName,
        };

        public IEnumerable<PersonDto> Map(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                yield return new PersonDto
                {
                    Id = person.Id,
                    Age = person.Age,
                    Company = person.Company,
                    Email = person.Email,
                    FirstName = person.FirstName,
                    LastName = person.LastName
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
            foreach (var dto in dtos)
            {
                yield return new Person
                {
                    Id = dto.Id,
                    Age = dto.Age,
                    Company = dto.Company,
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName
                };
            }
        }
    }
}
