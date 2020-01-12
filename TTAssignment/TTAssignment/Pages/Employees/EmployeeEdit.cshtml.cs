using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TTAssignment.Core;
using TTAssignment.Data;

namespace TTAssignment.Pages.Employees
{
    public class EmployeeEditModel : PageModel
    {
        private IEmployeeData _employeeData;
        private IHtmlHelper _htmlHelper;

        [BindProperty]
        public Employee Employee { get; set; }

        public IEnumerable<SelectListItem> EmpTypes { get; set; }
        public EmployeeEditModel(IEmployeeData employeeData, IHtmlHelper htmlHelper)
        {
            _employeeData = employeeData;
            this._htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? EmployeeId)
        {
            EmpTypes = _htmlHelper.GetEnumSelectList<EmployeeType>();

            if (EmployeeId.HasValue)
            {
                Employee = _employeeData.GetEmployee(EmployeeId.Value);
            }
            else
            {
                Employee = new Employee();
            }

            if (Employee == null)
                return RedirectToPage("./NotFound");
            else
                return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                EmpTypes = _htmlHelper.GetEnumSelectList<EmployeeType>();

                return Page();
            }

            if (Employee.EmployeeId > 0)
                Employee = _employeeData.Update(Employee);
            else
            {
                _employeeData.Add(Employee);
            }
            _employeeData.Commit();
            TempData["EmployeeSavedMsg"] = "Employee Saved Sucessfully..";
            return RedirectToPage("./EmployeeDetail", new { employeeId = Employee.EmployeeId });

        }
    }
}
