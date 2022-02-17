using System;

namespace Timesheets.BusinessLayer.Dto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }

        //public ICollection<Sheet> Sheets { get; set; }
    }
}
