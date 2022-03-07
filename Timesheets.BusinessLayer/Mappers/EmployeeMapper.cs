using System.Linq;
using System.Collections.Generic;
using Timesheets.BusinessLayer.Abstractions.Mappers;
using Timesheets.BusinessLayer.Dto;
using Timesheets.DataLayer.Models;

namespace Timesheets.BusinessLayer.Mappers
{
    public class EmployeeMapper : IEmployeeMapper
    {
        public EmployeeDto Map(Employee model) => new()
        {
            Id = model.Id,
            UserId = model.UserId,
            IsDeleted = model.IsDeleted,
        };

        public IEnumerable<EmployeeDto> Map(IEnumerable<Employee> models)
        {
            return models.Select(m => new EmployeeDto
            {
                Id = m.Id,
                UserId = m.UserId,
                IsDeleted = m.IsDeleted,
            });
        }

        public Employee Map(EmployeeDto dto) => new()
        {
            Id = dto.Id,
            UserId = dto.UserId,
            IsDeleted = dto.IsDeleted,
        };

        public IEnumerable<Employee> Map(IEnumerable<EmployeeDto> dtos)
        {
            return dtos.Select(m => new Employee
            {
                Id = m.Id,
                UserId = m.UserId,
                IsDeleted = m.IsDeleted,
            });
        }

    }
}
