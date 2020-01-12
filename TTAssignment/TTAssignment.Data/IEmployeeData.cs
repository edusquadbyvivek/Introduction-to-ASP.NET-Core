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
        int Commit();
    }

    public class InMemoryEmployeeData : IEmployeeData
    {
        List<Employee> lstEmployee;
        public InMemoryEmployeeData()
        {
            lstEmployee = new List<Employee>() { new Employee { FirstName = "Vivek", LastName = "Gaur", EmployeeId = 1,
                EmpType = EmployeeType.Permanent, DOB = new DateTime(1985, 09, 19) },
            new Employee { FirstName = "Arjun", LastName = "Rampal", EmployeeId = 2,
                EmpType = EmployeeType.Contractor, DOB = new DateTime(1981, 08, 26)} };
        }

        public Employee Add(Employee newemployee)
        {
            lstEmployee.Add(newemployee);
            newemployee.EmployeeId = lstEmployee.Max(e => e.EmployeeId + 1);
            return newemployee;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Employee> GetAll()
        {
            return from emp in lstEmployee
                   orderby emp.FirstName
                   select emp;

        }

        public Employee GetEmployee(int EmployeeId)
        {
            return lstEmployee.SingleOrDefault<Employee>(e => e.EmployeeId.Equals(EmployeeId));
        }

        public IEnumerable<Employee> GetEmployeeByName(string name = null)
        {
            return from emp in lstEmployee
                   where string.IsNullOrEmpty(name) || emp.FirstName.StartsWith(name)
                   orderby emp.FirstName
                   select emp;
        }

        public Employee Update(Employee updatedEmployee)
        {
            var emp = lstEmployee.SingleOrDefault<Employee>(e => e.EmployeeId == updatedEmployee.EmployeeId);

            if(emp !=null)
            {
                emp.FirstName = updatedEmployee.FirstName;
                emp.LastName = updatedEmployee.LastName;
                emp.EmpType = updatedEmployee.EmpType;
            }

            return emp;
        }
    }
}
