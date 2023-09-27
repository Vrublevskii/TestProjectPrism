using TestProjectPrism.DatabaseManager.Contexts;
using TestProjectPrism.DatabaseManager.Entity;
using TestProjectPrism.Utils;

namespace TestProjectPrism.DatabaseManager.Managers.EntityManager
{
    public class PositionManager : IDbEntityManager
    {
        private static IDbEntityManager _positionManager;

        private PositionManager() { }

        public static IDbEntityManager GetInstance()
        {
            return _positionManager ??= new PositionManager();
        }

        public void CreateInContext(EmployeeContext employeeContext, DbEntity dbEntity)
        {
            employeeContext.Positions.Add((Position)dbEntity);
        }

        public void UpdateInContext(EmployeeContext employeeContext, DbEntity dbEntity, DbEntity emptyDbEntity)
        {
            ((Position)dbEntity).ObjectClonerWithout((Position)emptyDbEntity, "Employees");
        } // cast нужен?

        public void DeleteInContext(EmployeeContext employeeContext, DbEntity dbEntity)
        {
            employeeContext.Positions.Remove((Position)dbEntity);
        }

        public IDbEntityManager GetEmptyForDialog()
        {
            throw new System.NotImplementedException();
        }
    }
}
