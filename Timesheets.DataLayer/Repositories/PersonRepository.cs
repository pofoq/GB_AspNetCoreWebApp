using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.DataLayer.Abstractions.Repositories;
using Timesheets.DataLayer.Models;

namespace Timesheets.DataLayer.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Repo _repo;

        public PersonRepository(Repo repo)
        {
            _repo = repo;
        }

        public Task<Person> AddAsync(Person model, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Person model, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetAllAsync(int count, int page, string searchByName, CancellationToken token)
        {
            var res = await Task.Run(() =>
            {
                var result = _repo.Data
                    .Where(x => x.FirstName.Contains(searchByName) || x.LastName.Contains(searchByName))
                    .Skip(count * (page - 1))
                    .Take(count);

                return result;
            }, token);

            return res;
        }

        public async Task<Person> GetByIdAsync(int id, CancellationToken token)
        {
            var res = await Task.Run(() =>
            {
                return _repo.Data
                    .Where(x => x.Id == id).FirstOrDefault();
            }, token);

            return res;
        }

        public Task<bool> UpdateAsync(Person model, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
