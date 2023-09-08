using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using TestProjectPrism.DatabaseManager.Contexts;
using TestProjectPrism.Utils;
using TestProjectPrism.Views;

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
            containerRegistry.RegisterContext<EmployeeContext>("EmployeeDB.db");

            var container = containerRegistry.GetContainer();
            using var context = container.Resolve<EmployeeContext>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule(typeof(UIModule.UIModule));
            moduleCatalog.AddModule(typeof(DialogModule.DialogModule));
        }


    }
}
