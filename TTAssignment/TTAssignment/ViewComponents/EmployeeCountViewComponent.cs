using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TTAssignment.Data;

namespace TTAssignment.ViewComponents
{
    public class EmployeeCountViewComponent: ViewComponent
    {
        private readonly IEmployeeData _employeedata;
        public EmployeeCountViewComponent(IEmployeeData employeedata)
        {
            _employeedata = employeedata;
        }

        public IViewComponentResult Invoke()
        {
            var count = _employeedata.EmployeeCount();
            return View(count);
        }
    }
}
