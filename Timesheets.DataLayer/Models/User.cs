using System;

namespace Timesheets.DataLayer.Models
{
    public sealed class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
    }
}
