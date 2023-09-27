using System.Collections.Generic;
using TestProjectPrism.DatabaseManager.Managers.EntityManager;

namespace TestProjectPrism.DatabaseManager.Entity
{
    public partial class Department : DbEntity
    {
        public int Id { get; set; }

        public string NameDepartment { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public override IDbEntityManager GetManager() => DepartmentManager.GetInstance();
    }
}