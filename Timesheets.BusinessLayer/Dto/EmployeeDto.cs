using System;

namespace Timesheets.BusinessLayer.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }

        //public ICollection<Sheet> Sheets { get; set; }
    }
}
