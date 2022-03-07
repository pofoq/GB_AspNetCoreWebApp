using System.ComponentModel.DataAnnotations;

namespace Timesheets.BusinessLayer.Requests
{
    public sealed class AddUserRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
