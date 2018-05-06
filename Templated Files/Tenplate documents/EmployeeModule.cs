using EmployeeModule.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModule
{
    public class EmployeeModule : IModule
    {
        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("EmployeeRegion", ()=>this.container.Resolve<EmployeeView>());
        }

        public EmployeeModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;
    }
}
