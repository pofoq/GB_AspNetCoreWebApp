using System.ComponentModel.DataAnnotations;

namespace Timesheets.DataLayer.Models
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Company { get; set; }

        [Range(15, 100)]
        public int Age { get; set; }
    }
}
