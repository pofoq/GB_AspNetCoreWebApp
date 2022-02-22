using Timesheets.BusinessLayer.Dto;
using Timesheets.BusinessLayer.Requests;

namespace Timesheets.BusinessLayer.Abstractions.Services
{
    public interface IUserService : IServiceBase<UserDto, int, AddUserRequest>
    {

    }
}
