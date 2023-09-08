using System.Threading.Tasks;
using TestProjectPrism.DatabaseManager.Contexts;
using TestProjectPrism.DatabaseManager.Entity;
using TestProjectPrism.Utils;

namespace TestProjectPrism.DatabaseManager
{
    public class CRUDRepository
    {
        public static async Task CreateEmployee(EmployeeContext employeeContext, Employee employee)
        {
            await employeeContext.Employees.AddAsync(employee);
            await employeeContext.SaveChangesAsync();
        }

        public static async Task UpdateEmployee(EmployeeContext employeeContext, Employee employee, Employee emptyEmployee)
        {
            employee.ObjectClonerWithout(emptyEmployee, "Department", "Position");
            //employee.Department.ObjectClonerWithout(emptyEmployee.Department, "Id", "Employees");
            //employee.Position.ObjectClonerWithout(emptyEmployee.Position, "Id", "Employees");
            employee.Department = emptyEmployee.Department;
            employee.Position = emptyEmployee.Position;
            await employeeContext.SaveChangesAsync();
        }

        public static async Task DeleteEmployee(EmployeeContext employeeContext, Employee employee)
        {
            employeeContext.Employees.Remove(employee);
            await employeeContext.SaveChangesAsync();
        }

    }
}
