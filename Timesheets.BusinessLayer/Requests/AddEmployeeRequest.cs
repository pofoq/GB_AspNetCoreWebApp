
namespace Timesheets.BusinessLayer.Requests
{
    public sealed class AddEmployeeRequest
    {
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
