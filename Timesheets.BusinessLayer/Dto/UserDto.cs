using System;

namespace Timesheets.BusinessLayer.Dto
{
    public sealed class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
