using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using NavigationModule;
using Infrastructure.Services;
using Infrastructure.Repository;
using HardwareModule;
using RequestModule;

namespace CompositeUI
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog catalog = (ModuleCatalog)this.ModuleCatalog;
            catalog.AddModule(typeof(NavigationModule.NavigationModule));
            catalog.AddModule(typeof(EmployeeModule.EmployeeModule));

            catalog.AddModule(typeof(SoftwareModule.SoftWareModule), InitializationMode.OnDemand); //只加载第一个
            catalog.AddModule(typeof(HardWareModule), InitializationMode.OnDemand);
            catalog.AddModule(typeof(RequestModule.RequestModule), InitializationMode.OnDemand);

        }

        protected override void ConfigureContainer()
        {
            Container.RegisterType<IEmployeeService, EmployeeService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IHelpDeskRepository, HelpDeskXMLRepository>();
            base.ConfigureContainer();
        }
    }
}
