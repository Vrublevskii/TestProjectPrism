using System;
using TestProjectPrism.DatabaseManager.Contexts;
using TestProjectPrism.DatabaseManager.Entity;
using TestProjectPrism.Utils;

namespace TestProjectPrism.DatabaseManager.Managers.EntityManager
{
    public class EmployeeManager : IDbEntityManager
    {
        private static IDbEntityManager _employeeManager;

        private EmployeeManager() { }

        public static IDbEntityManager GetInstance()
        {
            return _employeeManager ??= new EmployeeManager();
        }

        public void CreateInContext(EmployeeContext employeeContext, DbEntity dbEntity)
        {
            employeeContext.Employees.Add((Employee)dbEntity);
        }

        public void UpdateInContext(EmployeeContext employeeContext, DbEntity dbEntity, DbEntity emptyDbEntity)
        {
            Employee employee = (Employee)dbEntity;
            Employee emptyEmployee = (Employee)emptyDbEntity;
            employee.ObjectClonerWithout(emptyEmployee, "Department", "Position");
            employee.Position = emptyEmployee.Position;
            employee.Department = emptyEmployee.Department;
        } // cast нужен?

        public void DeleteInContext(EmployeeContext employeeContext, DbEntity dbEntity)
        {
            employeeContext.Employees.Remove((Employee)dbEntity);
        }

        public DbEntity GetEmptyForDialog()
        {
            return new Employee()
            {
                Department = new Department(),
                Position = new Position()
            };
        }
    }
}
