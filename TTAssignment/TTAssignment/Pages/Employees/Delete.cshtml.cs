using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TTAssignment.Core;
using TTAssignment.Data;

namespace TTAssignment.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeData _employeeData;
        public DeleteModel(IEmployeeData employeeData)
        {
            this._employeeData = employeeData;
        }
        public Employee Employee { get; set; }

        public IActionResult OnGet(int EmployeeId)
        {
            Employee = _employeeData.GetEmployee(EmployeeId);
            if(Employee ==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }

        public IActionResult OnPost(int EmployeeId)
        {
            var emp  = _employeeData.Delete(EmployeeId);
            _employeeData.Commit();

            if (emp == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{emp.FirstName} deleted..";
            return RedirectToPage("./Employeelist");
        }
    }
}