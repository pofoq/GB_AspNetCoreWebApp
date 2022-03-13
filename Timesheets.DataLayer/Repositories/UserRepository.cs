﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.DataLayer.Abstractions.Repositories;
using Timesheets.DataLayer.Models;

namespace Timesheets.DataLayer.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly TimesheetDbContext _context;

        public UserRepository(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User model, CancellationToken token)
        {
            var r = await _context.Users.AddAsync(model, token);
            await _context.SaveChangesAsync(token);
            return r.Entity;
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken token)
        {
            var dbEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken: token);

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

        public async Task<IEnumerable<User>> GetAllAsync(int count, int page, string searchByName, CancellationToken token)
        {
            return await _context.Users.AsNoTracking().Where(u => u.Username.ToLower().Contains(searchByName.ToLower())).Skip(count * (page - 1)).Take(count).ToArrayAsync(token);
        }

        public async Task<User> GetByIdAsync(int id, CancellationToken token)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, token);
        }

        public async Task<User> GetByTokenAsync(string refreshToken, CancellationToken token)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.RefreshToken == refreshToken, token);
        }

        public async Task<User> GetByUsernameAsync(string username, byte[] passwordHash, CancellationToken token)
        {
            //return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username.ToLower(), token);
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username.ToLower() && u.PasswordHash == passwordHash, token);
        }

        public async Task<bool> UpdateAsync(User entity, CancellationToken token)
        {
            var dbEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id, token);

            if (dbEntity == null)
            {
                return false;
            }
            else
            {
                dbEntity.Username = entity.Username;
                dbEntity.Role = entity.Role;
                dbEntity.PasswordHash = entity.PasswordHash;
                dbEntity.RefreshToken = entity.RefreshToken;
                dbEntity.Expires = entity.Expires;
                await _context.SaveChangesAsync(token);
                return true;
            }
        }
    }
}
