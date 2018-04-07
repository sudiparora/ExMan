using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Services.Base
{
    public class LocatorService
    {

        public static IConfigurationManager ConfigurationManager
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IConfigurationManager>();
            }
        }


    }
}
