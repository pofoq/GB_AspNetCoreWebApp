using Timesheets.BusinessLayer.Dto;
using Timesheets.BusinessLayer.Requests;
using Timesheets.SecurityLayer.Abstractions.Services;

namespace Timesheets.BusinessLayer.Abstractions.Services
{
    public interface IUserService : IServiceBase<UserDto, int, AddUserRequest>, IAuthService
    {
        const string AuthKey = "THIS IS SOME VERY SECRET STRING!!! Im blue da ba dee da ba di da ba dee da ba di da d ba dee da ba di da ba dee";
    }
}
