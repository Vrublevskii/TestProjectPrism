using TestProjectPrism.DatabaseManager.Entity;

namespace TestProjectPrism.DatabaseManager
{
    public static class EntityFactory
    {
        public static Employee GetEmptyEmployee()
        {
            return new Employee()
            {
                Department = new Department(),
                Position = new Position()
            };
        }
    }
}
