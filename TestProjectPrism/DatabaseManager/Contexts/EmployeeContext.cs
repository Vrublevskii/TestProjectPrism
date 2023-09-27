using Microsoft.EntityFrameworkCore;
using TestProjectPrism.DatabaseManager.Entity;

namespace TestProjectPrism.DatabaseManager.Contexts
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> opt) : base(opt) => Database.EnsureCreated();
    }
}
