using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using FinCare.Views;
using PerFin.Core.Contracts;
using FinCare.Core;
using Prism.Modularity;

namespace FinCare
{
    public class Bootstrapper : UnityBootstrapper
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
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(FinCareClientModule));
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            Application.Current.MainWindow.Show();
        }
    }
}
