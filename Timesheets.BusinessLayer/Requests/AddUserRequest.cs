
namespace Timesheets.BusinessLayer.Requests
{
    public sealed class AddUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
