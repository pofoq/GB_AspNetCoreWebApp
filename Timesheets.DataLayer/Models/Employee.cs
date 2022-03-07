using System.ComponentModel.DataAnnotations;

namespace Timesheets.DataLayer.Models
{
    public sealed class Employee
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        //public ICollection<Sheet> Sheets { get; set; }
    }
}
