using System;
using TestProjectPrism.DatabaseManager.Entity;

namespace TestProjectPrism.DatabaseManager
{
    public static class EntityFactory
    {
        public static DbEntity GetEmptyEntity(Type entityType)
        {
            if (entityType == typeof(Employee))
            {
                return new Employee()
                {
                    Department = new Department(),
                    Position = new Position()
                };
            }
            else if (entityType == typeof(Department)) return new Department() { };
            else if (entityType == typeof(Position)) return new Position() { };
            else throw new NotImplementedException();
        }
    }
}
