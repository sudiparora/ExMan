using System.Collections.Generic;

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
