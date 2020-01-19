using System;
using System.ComponentModel.DataAnnotations;

namespace TTAssignment.Core
{
    /// <summary>
    /// Employee Class
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// EmployeeId
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Firstname of Employee
        /// </summary>
        [Required, StringLength(120)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name of Employee
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Employee Type i.e. Permanent or Contractor.
        /// </summary>
        [Required]
        public EmployeeType EmpType { get; set; }

    }
}
