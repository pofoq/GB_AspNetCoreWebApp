using System.Collections.Generic;
using Timesheets.BusinessLayer.Dto;
using Timesheets.DataLayer.Models;

namespace Timesheets.BusinessLayer
{
    public static class Mapper
    {
        public static PersonDto Map(Person person) => new PersonDto
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
    }
}
