using Microsoft.Extensions.DependencyInjection;
using Timesheets.DataLayer.Abstractions.Repositories;
using Timesheets.DataLayer.Repositories;

namespace Timesheets.DataLayer
{
    public static class RegisterServices
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddSingleton(new Repo());
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
