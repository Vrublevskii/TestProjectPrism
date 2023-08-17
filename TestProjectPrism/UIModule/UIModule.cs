using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using TestProjectPrism.UIModule.Views;

namespace TestProjectPrism.UIModule
{
    public class UIModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(EmployeeList));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
