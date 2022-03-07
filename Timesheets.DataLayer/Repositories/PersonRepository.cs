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
        private readonly Repo _db;
        private int _lastId = 0;


        public PersonRepository(Repo repo)
        {
            _db = repo;
            _lastId = _db.Persons.Select(p => p.Id).Max();
        }

        public async Task<Person> AddAsync(Person model, CancellationToken token)
        {
            model.Id = ++_lastId;
            return await Task.Run(() =>
            {
                _db.Persons.Add(model);
                return model;
            }, token);
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken token)
        {
            return await Task.Run(async () =>
            {
                return _db.Persons.Remove(await GetByIdAsync(id, token));
            }, token);
        }

        public async Task<IEnumerable<Person>> GetAllAsync(int count, int page, string searchByName, CancellationToken token)
        {
            var res = await Task.Run(() =>
            {
                var result = _db.Persons
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
                return _db.Persons
                    .Where(x => x.Id == id).FirstOrDefault();
            }, token);
            return res;
        }

        public async Task<bool> UpdateAsync(Person model, CancellationToken token)
        {
            return await Task.Run(async () =>
            {
                var el = await GetByIdAsync(model.Id, token);
                if (el != null)
                {
                    el.Age = model.Age;
                    el.FirstName = model.FirstName;
                    el.LastName = model.LastName;
                    el.Email = model.Email;
                    el.Company = model.Company;
                    return true;
                }
                return false;
            }, token);
        }
    }
}