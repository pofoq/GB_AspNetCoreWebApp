
namespace Timesheets.BusinessLayer.Requests
{
    public class AddUserRequest
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
