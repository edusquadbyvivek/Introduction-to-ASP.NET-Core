using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TTAssignment.Core;

namespace TTAssignment.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            :base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
