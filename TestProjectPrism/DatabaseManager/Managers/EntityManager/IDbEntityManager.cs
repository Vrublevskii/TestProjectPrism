using TestProjectPrism.DatabaseManager.Contexts;
using TestProjectPrism.DatabaseManager.Entity;

namespace TestProjectPrism.DatabaseManager.Managers.EntityManager
{

    public interface IDbEntityManager
    {
        public void CreateInContext(EmployeeContext employeeContext, DbEntity dbEntity);

        public void UpdateInContext(EmployeeContext employeeContext, DbEntity dbEntity, DbEntity emptyDbEntity);

        public void DeleteInContext(EmployeeContext employeeContext, DbEntity dbEntity);

        public DbEntity GetEmptyForDialog();
        
    }
}
