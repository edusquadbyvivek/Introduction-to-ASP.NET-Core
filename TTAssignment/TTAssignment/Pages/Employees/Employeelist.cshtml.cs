using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using TTAssignment.Core;
using TTAssignment.Data;

namespace TTAssignment.Pages.Employees
{
    public class EmployeelistModel : PageModel
    {
        private IConfiguration _config;
        private IEmployeeData _employeedata;

        public string EmployeeHeader = string.Empty;

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Employee> lstEmployees { get; set; }
        public EmployeelistModel(IConfiguration config, IEmployeeData employeedata)
        {
            _config = config;
            _employeedata = employeedata;
        }
        public void OnGet()
        {
            EmployeeHeader = _config["EmployeeHeading"];
            lstEmployees = _employeedata.GetEmployeeByName(SearchTerm);

        }
    }
}