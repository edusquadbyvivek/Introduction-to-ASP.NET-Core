using System;
using System.Collections.Generic;
using System.Text;
using TTAssignment.Core;
using System.Linq;

namespace TTAssignment.Data
{
    public class SqlEmployeeData : IEmployeeData
    {
        private readonly EmployeeDbContext db;
        public SqlEmployeeData(EmployeeDbContext db)
        {
            this.db = db;
        }

        public Employee Add(Employee newemployee)
        {
            db.Add(newemployee);
            return newemployee;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Employee Delete(int id)
        {
            var emp = GetEmployee(id);
            if(emp !=null)
            {
                db.Employees.Remove(emp);
            }
            return emp;
        }

        public IEnumerable<Employee> GetAll()
        {
            var query = from e in db.Employees
                        orderby e.FirstName
                        select e;

            return query;
        }

        public Employee GetEmployee(int EmployeeId)
        {
            return db.Employees.Find(EmployeeId);
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            var query = from e in db.Employees
                        where e.FirstName.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby e.FirstName
                        select e;

            return query;
        }

        public Employee Update(Employee updatedEmployee)
        {
            var entity = db.Employees.Attach(updatedEmployee);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedEmployee;
        }
    }
}
