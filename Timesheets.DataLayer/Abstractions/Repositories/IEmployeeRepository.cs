using System;
using Timesheets.DataLayer.Models;

namespace Timesheets.DataLayer.Abstractions.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee, Guid>
    {

    }
}
