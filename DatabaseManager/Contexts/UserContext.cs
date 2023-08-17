using DatabaseManager.Entity;
using Microsoft.EntityFrameworkCore;

namespace DatabaseManager.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public UserContext(DbContextOptions<UserContext> opt) : base(opt) => Database.EnsureCreated();
    }
}
