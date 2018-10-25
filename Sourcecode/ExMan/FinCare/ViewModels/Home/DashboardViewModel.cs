using FinCare.Core;
using PerFin.Entities.Authentication;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCare.ViewModels.Home
{
    public class DashboardViewModel: ViewModelBase
    {

        private List<ComponentType> registeredComponentTypes;


        public List<ComponentType> RegisteredComponentTypes
        { get { return registeredComponentTypes; }
            set
            {
                SetProperty(ref registeredComponentTypes, value);
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            RegisteredComponentTypes = (List<ComponentType>)navigationContext.Parameters["RegisteredComponentTypes"];
        }

    }
}
