using Prism.Ioc;
using Prism.Modularity;
using TestProjectPrism.DialogModule.ViewModels;
using TestProjectPrism.DialogModule.Views;

namespace TestProjectPrism.DialogModule
{
    public class DialogModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddEditEmployee, AddEditEmployeeViewModel>();
        }
    }
}
