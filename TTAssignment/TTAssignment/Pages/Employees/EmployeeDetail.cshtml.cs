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
    public class EmployeeDetailModel : PageModel
    {
        private IEmployeeData _employeeData;
        public Employee employee { get; set; }

        [TempData]
        public string EmployeeSavedMsg { get; set; }

        public EmployeeDetailModel(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        public IActionResult OnGet(int EmployeeId)
        {

            employee = _employeeData.GetEmployee(EmployeeId);
            if(employee == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
            

        }
    }
}