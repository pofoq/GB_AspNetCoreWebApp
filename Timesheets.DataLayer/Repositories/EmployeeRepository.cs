using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.DataLayer.Abstractions.Repositories;
using Timesheets.DataLayer.Models;

namespace Timesheets.DataLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TimesheetDbContext _context;
        private readonly IUserRepository _userRepository;

        public EmployeeRepository(TimesheetDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<Employee> AddAsync(Employee model, CancellationToken token)
        {
            var r = await _context.Employees.AddAsync(model, token);
            await _context.SaveChangesAsync(token);
            return r.Entity;
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken token)
        {
            var dbEntity = await _context.Employees.FirstOrDefaultAsync(u => u.Id == id, cancellationToken: token);

            if (dbEntity == null)
            {
                return false;
            }
            else
            {
                _context.Remove(dbEntity);
                await _context.SaveChangesAsync(token);
                return true;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(int count, int page, string searchByName, CancellationToken token)
        {
            if (searchByName.Length > 0)
            {
                var users = await _userRepository.GetAllAsync(count, page, searchByName, token);
                return await _context.Employees.AsNoTracking().Where(e => users.Select(u => u.Id).Contains(e.UserId)).ToListAsync(token);
            }
            return await _context.Employees.AsNoTracking().Skip(count * (page - 1)).Take(count).ToArrayAsync(token);
        }

        public async Task<Employee> GetByIdAsync(int id, CancellationToken token)
        {
            return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, token);
        }

        public async Task<bool> UpdateAsync(Employee model, CancellationToken token)
        {
            var dbEntity = await _context.Employees.FirstOrDefaultAsync(u => u.Id == model.Id, token);

            if (dbEntity == null)
            {
                return false;
            }
            else
            {
                dbEntity.UserId = model.UserId;
                dbEntity.IsDeleted = model.IsDeleted;
                await _context.SaveChangesAsync(token);
                return true;
            }
        }
    }
}
