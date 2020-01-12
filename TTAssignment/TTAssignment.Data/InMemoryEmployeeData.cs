using System.Collections.Generic;
using System.Linq;
using TTAssignment.Core;

namespace TTAssignment.Data
{
    public class InMemoryEmployeeData : IEmployeeData
    {
        List<Employee> lstEmployee;
        public InMemoryEmployeeData()
        {
            lstEmployee = new List<Employee>() { new Employee { FirstName = "Vivek", LastName = "Gaur", EmployeeId = 1,
                EmpType = EmployeeType.Permanent},
            new Employee { FirstName = "Arjun", LastName = "Rampal", EmployeeId = 2,
                EmpType = EmployeeType.Contractor} };
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

        public Employee Delete(int id)
        {
            var emp = lstEmployee.SingleOrDefault<Employee>(e => e.EmployeeId == id);

            if (emp != null)
            {
                lstEmployee.Remove(emp);
            }

            return emp;
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

            if (emp != null)
            {
                emp.FirstName = updatedEmployee.FirstName;
                emp.LastName = updatedEmployee.LastName;
                emp.EmpType = updatedEmployee.EmpType;
            }

            return emp;
        }

    }
}
