using System.Collections.Generic;
using Timesheets.BusinessLayer.Abstractions.Mappers;
using Timesheets.BusinessLayer.Dto;
using Timesheets.DataLayer.Models;

namespace Timesheets.BusinessLayer.Mappers
{
    public class UserMapper : IUserMapper
    {
        public UserDto Map(User model) => new()
        {
            Id = model.Id,
            PasswordHash = model.PasswordHash,
            Role = model.Role,
            Username = model.Username
        };

        public IEnumerable<UserDto> Map(IEnumerable<User> models)
        {
            foreach (var model in models)
            {
                yield return new UserDto
                {
                    Id = model.Id,
                    PasswordHash = model.PasswordHash,
                    Role = model.Role,
                    Username = model.Username
                };
            }
        }

        public User Map(UserDto dto) => new()
        {
            Id = dto.Id,
            PasswordHash = dto.PasswordHash,
            Role = dto.Role,
            Username = dto.Username
        };

        public IEnumerable<User> Map(IEnumerable<UserDto> dtos)
        {
            foreach (var dto in dtos)
            {
                yield return new User
                {
                    Id = dto.Id,
                    PasswordHash = dto.PasswordHash,
                    Role = dto.Role,
                    Username = dto.Username
                };
            }
        }

    }
}
