using System;

namespace Timesheets.BusinessLayer.Dto
{
    public sealed class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
