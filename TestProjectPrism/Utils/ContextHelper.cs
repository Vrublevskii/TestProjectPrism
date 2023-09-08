using Microsoft.EntityFrameworkCore;
using Prism.Ioc;

namespace TestProjectPrism.Utils
{
    public static class ContextHelper
    {
        public static void RegisterContext<T>
            (this IContainerRegistry containerRegistry, string dbFilename) where T : DbContext
        {
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseSqlite($"Filename={dbFilename}");
            containerRegistry.RegisterInstance(builder.Options);
            containerRegistry.Register<T>();
        }
    }
}
