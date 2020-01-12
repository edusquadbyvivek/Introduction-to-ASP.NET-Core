using System;
using System.ComponentModel.DataAnnotations;

namespace TTAssignment.Core
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required, StringLength(120)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public EmployeeType EmpType { get; set; }

    }
}
