using System.Collections.Generic;
using Timesheets.BusinessLayer.Dto;
using Timesheets.DataLayer.Models;
using System.Linq;

namespace Timesheets.BusinessLayer
{
    public static class Mapper
    {
        public static PersonDto Map(Person person) => new()
        {
            Id = person.Id,
            Age = person.Age,
            Company = person.Company,
            Email = person.Email,
            FirstName = person.FirstName,
            LastName = person.LastName,
        };

        public static IEnumerable<PersonDto> Map(IEnumerable<Person> persons)
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

        public static Person Map(PersonDto dto) => new()
        {
            Id = dto.Id,
            Age = dto.Age,
            Company = dto.Company,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
        };

        public static IEnumerable<Person> Map(IEnumerable<PersonDto> persons)
        {
            return persons.Select(x => new Person()
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
