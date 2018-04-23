using ExMan.Desktop.Client.Views;
using Prism.Modularity;
using Prism.Unity;
using Microsoft.Practices.Unity;

namespace ExMan.Desktop.Client
{
    public class ExManClientModule : IModule
    {

        private IUnityContainer container;

        public ExManClientModule(IUnityContainer container)
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
