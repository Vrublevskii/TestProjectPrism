using DryIoc;
using Microsoft.EntityFrameworkCore;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using TestProjectPrism.DatabaseManager.Contexts;
using TestProjectPrism.ShellModule.Views;

namespace TestProjectPrism
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var builder = new DbContextOptionsBuilder<UserContext>();
            builder.UseSqlite("Filename=textdb.db");
            containerRegistry.RegisterInstance(builder.Options);
            containerRegistry.Register<UserContext>();

            var container = containerRegistry.GetContainer();
            using var context = container.Resolve<UserContext>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule(typeof(UIModule.UIModule));
        }
    }
}
