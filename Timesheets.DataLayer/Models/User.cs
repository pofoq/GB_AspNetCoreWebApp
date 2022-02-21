using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.DataLayer.Models
{
    //[Table("Users", Schema = "ts")]
    public sealed class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }
        public string Role2 { get; set; }
    }
}
