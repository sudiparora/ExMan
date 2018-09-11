using PerFin.Desktop.Views;
using Prism.Modularity;
using Prism.Unity;
using Microsoft.Practices.Unity;

namespace PerFin.Desktop
{
    public class PerFinClientModule : IModule
    {

        private IUnityContainer container;

        public PerFinClientModule(IUnityContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterTypeForNavigation<Login>();
            container.RegisterTypeForNavigation<Home>();
        }
    }
}
