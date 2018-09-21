using FinCare.Views.Home;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCare
{
    public class FinCareClientModule: IModule
    {
        private IUnityContainer container;

        public FinCareClientModule(IUnityContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterTypeForNavigation<Login>();
            //container.RegisterTypeForNavigation<Home>();
        }
    }
}
