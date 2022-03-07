
namespace Timesheets.SecurityLayer.Dto
{
    public sealed class TokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
