using Microsoft.EntityFrameworkCore;
using TestProjectPrism.DatabaseManager.Entity;

namespace TestProjectPrism.DatabaseManager.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public UserContext(DbContextOptions<UserContext> opt) : base(opt) => Database.EnsureCreated();
    }
}
