using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.DataLayer.Models
{
    [Table("Employee", Schema = "ts")]
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }

        //public ICollection<Sheet> Sheets { get; set; }
    }
}
