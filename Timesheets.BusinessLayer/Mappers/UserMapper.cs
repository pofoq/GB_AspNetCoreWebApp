using System.Collections.Generic;
using Timesheets.BusinessLayer.Abstractions.Mappers;
using Timesheets.BusinessLayer.Dto;
using Timesheets.DataLayer.Models;
using System.Linq;
using Timesheets.SecurityLayer.Abstractions.Services;

namespace Timesheets.BusinessLayer.Mappers
{
    public class UserMapper : IUserMapper
    {
        public UserDto Map(User model) => new()
        {
            Id = model.Id,
            Role = model.Role,
            Username = model.Username,
            Password = string.Empty,
        };

        public IEnumerable<UserDto> Map(IEnumerable<User> models)
        {
            foreach (var model in models)
            {
                yield return new UserDto
                {
                    Id = model.Id,
                    Role = model.Role,
                    Username = model.Username,
                    Password = string.Empty,
                };
            }
        }

        public User Map(UserDto dto) => new()
        {
            Id = dto.Id,
            Role = dto.Role,
            Username = dto.Username,
            PasswordHash = SecurityService.GetPasswordHash(dto.Password)
        };

        public IEnumerable<User> Map(IEnumerable<UserDto> dtos)
        {
            return dtos.Select(d => new User
            {
                Id = d.Id,
                Role = d.Role,
                Username = d.Username,
                PasswordHash = SecurityService.GetPasswordHash(d.Password)
            });
        }

    }
}
