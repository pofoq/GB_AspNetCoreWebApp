using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.DataLayer.Models
{
    public sealed class User
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
    }
}
