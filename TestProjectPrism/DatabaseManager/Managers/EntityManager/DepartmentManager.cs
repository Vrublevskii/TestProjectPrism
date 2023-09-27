using TestProjectPrism.DatabaseManager.Contexts;
using TestProjectPrism.DatabaseManager.Entity;
using TestProjectPrism.Utils;

namespace TestProjectPrism.DatabaseManager.Managers.EntityManager
{
    public class DepartmentManager : IDbEntityManager
    {
        private static IDbEntityManager _departmentManager;

        private DepartmentManager() { }

        public static IDbEntityManager GetInstance()
        {
            return _departmentManager ??= new DepartmentManager();
        }

        public void CreateInContext(EmployeeContext employeeContext, DbEntity dbEntity)
        {
            employeeContext.Departments.Add((Department)dbEntity);
        }

        public void UpdateInContext(EmployeeContext employeeContext, DbEntity dbEntity, DbEntity emptyDbEntity)
        {
            ((Department)dbEntity).ObjectClonerWithout((Department)emptyDbEntity, "Employees");
        } // cast нужен?

        public void DeleteInContext(EmployeeContext employeeContext, DbEntity dbEntity)
        {
            employeeContext.Departments.Remove((Department)dbEntity);
        }
    }
}
