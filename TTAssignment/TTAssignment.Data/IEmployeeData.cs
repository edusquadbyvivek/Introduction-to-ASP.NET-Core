using System;
using System.Collections.Generic;
using System.Linq;
using TTAssignment.Core;

namespace TTAssignment.Data
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetEmployeeByName(string name);

        Employee GetEmployee(int EmployeeId);

        Employee Update(Employee updatedEmployee);

        Employee Add(Employee newemployee);

        Employee Delete(int id);
        int Commit();
    }

    
}
