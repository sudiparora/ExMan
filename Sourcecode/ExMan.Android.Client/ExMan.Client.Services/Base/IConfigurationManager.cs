using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Services.Base
{
    public interface IConfigurationManager
    {
        Configurations GetConfigurations();
    }

    public class Configurations
    {
        public Dictionary<string, object> AppSettings;
    }
    
}
