using System.Collections.Generic;

namespace TestProjectPrism.DatabaseManager.Entity
{
    public partial class Department
    {
        public int Id { get; set; }

        public string NameDepartment { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}