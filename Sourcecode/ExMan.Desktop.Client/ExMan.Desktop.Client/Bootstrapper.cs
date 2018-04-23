using ExMan.Desktop.Client.Core;
using ExMan.Desktop.Client.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using System;

namespace ExMan.Desktop.Client
{
    public class Bootstrapper: UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<DesktopLocatorService, DesktopLocatorService>(new ContainerControlledLifetimeManager());
            InitializeServices();
        }

        private void InitializeServices()
        {
            Container.Resolve<DesktopLocatorService>();
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ExManClientModule));
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            Application.Current.MainWindow.Show();
        }

    }
}
