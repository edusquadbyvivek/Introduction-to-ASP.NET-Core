using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TTAssignment.Core;
using TTAssignment.Data;

namespace TTAssignmentUnitTests
{
    /// <summary>
    /// Sample Test case for Moq implementation.
    /// </summary>
    [TestClass]
    public class EmployeeDataTest
    {
        private IEmployeeData _employeedata = null;

        [TestMethod]
        public void EmployeeData_EmployeeCount()
        {
            // Arrange
            var mock = new Mock<IEmployeeData>();
            mock.Setup(p => p.EmployeeCount()).Returns(3);

            //Act
            _employeedata = mock.Object;

            // Assert
            Assert.AreEqual(_employeedata.EmployeeCount(), 3);
        }
    }
}
