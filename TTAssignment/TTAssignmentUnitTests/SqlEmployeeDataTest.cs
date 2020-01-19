using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TTAssignment.Core;
using TTAssignment.Data;

namespace TTAssignmentUnitTests
{


    [TestClass]
    public class SqlEmployeeDataTest
    {
        [TestMethod]
        public void SqlEmployeeData_GetAll_Test()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
             .UseInMemoryDatabase(databaseName: "EmployeeDatabase")
             .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new EmployeeDbContext(options))
            {
                context.Employees.Add(new Employee { EmployeeId = 1, FirstName = "Vivek", EmpType = EmployeeType.Permanent, LastName = "Gaur" });
                context.Employees.Add(new Employee { EmployeeId = 2, FirstName = "Vivek_1", EmpType = EmployeeType.Permanent, LastName = "Sharma" });
                context.Employees.Add(new Employee { EmployeeId = 3, FirstName = "Vivek_2", EmpType = EmployeeType.Permanent, LastName = "Atharav"});
                context.SaveChanges();
            }

            // Act
            // Use a clean instance of the context to run the test
            using (var context = new EmployeeDbContext(options))
            {
                SqlEmployeeData EmployeeRepository = new SqlEmployeeData(context);
                IEnumerable<Employee> Employees = EmployeeRepository.GetAll();
    
            // Assert
            Assert.AreEqual(3, Employees.Count());
            }
        }

    }
}
