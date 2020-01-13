using Microsoft.VisualStudio.TestTools.UnitTesting;
using TTAssignment.Data;

namespace TTAssignmentUnitTests
{
    [TestClass]
    public class InMemoryEmployeeDataTest
    {
        private IEmployeeData _employeedata = null;

        public InMemoryEmployeeDataTest()
        {
            _employeedata = new InMemoryEmployeeData();
        }

        [TestMethod]
        public void InMemoryEmployeehasData_Add()
        {
            //Arrange
            TTAssignment.Core.Employee Emp = new TTAssignment.Core.Employee { FirstName = "First",
                LastName = "Last",
                EmpType = TTAssignment.Core.EmployeeType.Permanent };
            
            //Act
             _employeedata.Add(Emp);

            //Assert
            Assert.AreEqual(_employeedata.GetEmployee(3), Emp);
            Assert.AreEqual(_employeedata.EmployeeCount(), 3);

        }

        [TestMethod]
        public void InMemoryEmployeehasData_Delete()
        {
            //Arrange

            //Act
            _employeedata.Delete(3);

            //Assert
            Assert.AreEqual(_employeedata.GetEmployee(3), null);

        }
    }
}
