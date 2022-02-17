using System;
using Timesheets.BusinessLayer.Dto;

namespace Timesheets.BusinessLayer.Abstractions.Services
{
    public interface IUserService : IServiceBase<UserDto, Guid>
    {

    }
}
