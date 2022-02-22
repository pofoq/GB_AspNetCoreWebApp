
namespace Timesheets.DataLayer.Models
{
    public sealed class Employee
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }

        //public ICollection<Sheet> Sheets { get; set; }
    }
}
