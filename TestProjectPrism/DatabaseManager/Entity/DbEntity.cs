using TestProjectPrism.DatabaseManager.Managers.EntityManager;

namespace TestProjectPrism.DatabaseManager.Entity
{
    public abstract class DbEntity 
    {
        public abstract IDbEntityManager GetManager();
    }
}
