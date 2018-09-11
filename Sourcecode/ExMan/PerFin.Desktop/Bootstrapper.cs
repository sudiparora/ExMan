using PerFin.Desktop.Core;
using PerFin.Desktop.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using System;
using PerFin.Core.Contracts;
using PerFin.DataAccess.DAC;
using PerFin.Business.BDC;

namespace PerFin.Desktop
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
            Container.RegisterType<ILogger, DesktopLogger>();
            Container.RegisterType<IAppSettings, DesktopAppSettings>();
            //Container.RegisterType<UserDAC, UserDAC>();
            //Container.RegisterType<UserBDC, UserBDC>();
            InitializeServices();
        }

        private void InitializeServices()
        {
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(PerFinClientModule));
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            Application.Current.MainWindow.Show();
        }

    }
}
