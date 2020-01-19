using System;
using System.Collections.Generic;
using System.Linq;
using TTAssignment.Core;

namespace TTAssignment.Data
{
    /// <summary>
    /// Main IEmployee interface or Employee related operations.
    /// </summary>
    public interface IEmployeeData
    {
        /// <summary>
        /// Get all Employees.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetAll();

        /// <summary>
        /// Get Employee by Name for search Employee by Name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of Employee</returns>
        IEnumerable<Employee> GetEmployeeByName(string name);

        /// <summary>
        /// return Employee based on EmployeeId.
        /// </summary>
        /// <param name="EmployeeId">Employee Id.</param>
        /// <returns></returns>
        Employee GetEmployee(int EmployeeId);

        /// <summary>
        /// Update Employee.
        /// </summary>
        /// <param name="updatedEmployee"></param>
        /// <returns></returns>
        Employee Update(Employee updatedEmployee);

        /// <summary>
        /// An an employee.
        /// </summary>
        /// <param name="newemployee"></param>
        /// <returns></returns>
        Employee Add(Employee newemployee);

        /// <summary>
        /// Delete an employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee Delete(int id);
        
        /// <summary>
        /// Commit the change to DB (Need to implement only in case of EF Core) 
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Get the Employee Count.
        /// </summary>
        /// <returns></returns>
        int EmployeeCount();
    }

    
}
