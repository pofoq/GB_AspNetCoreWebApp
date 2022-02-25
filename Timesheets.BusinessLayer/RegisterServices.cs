using Microsoft.Extensions.DependencyInjection;
using Timesheets.BusinessLayer.Abstractions.Mappers;
using Timesheets.BusinessLayer.Abstractions.Services;
using Timesheets.BusinessLayer.Mappers;
using Timesheets.BusinessLayer.Services;

namespace Timesheets.DataLayer
{
    public static class RegisterServices
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddSingleton<IPersonMapper, PersonMapper>();
            services.AddSingleton<IUserMapper, UserMapper>();
            services.AddSingleton<IEmployeeMapper, EmployeeMapper>();

            return services;
        }
    }
}
