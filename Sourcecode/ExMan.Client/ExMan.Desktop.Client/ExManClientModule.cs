using ExMan.Desktop.Client.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
