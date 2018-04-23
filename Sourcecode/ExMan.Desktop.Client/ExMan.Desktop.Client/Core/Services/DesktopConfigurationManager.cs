using ExMan.Client.Services.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Desktop.Client.Core
{
    public sealed class DesktopConfigurationManager : IConfigurationManager
    {

        ///// <summary>
        ///// http://geekswithblogs.net/BlackRabbitCoder/archive/2010/05/19/c-system.lazylttgt-and-the-singleton-design-pattern.aspx
        ///// The .net provided lazy initialization and singleton design pattern usage
        ///// </summary>
        //private static readonly Lazy<DesktopConfigurationManager> configurationManagerInstance
        //    = new Lazy<DesktopConfigurationManager>(() => new DesktopConfigurationManager());

        //internal static DesktopConfigurationManager ConfigurationManagerInstance
        //{
        //    get
        //    {
        //        return configurationManagerInstance.Value;
        //    }
        //}

        public DesktopConfigurationManager()
        {

        }


        public Configurations GetConfigurations()
        {
            Dictionary<string, object> configurations = new Dictionary<string, object>();
            foreach (string key in ConfigurationManager.AppSettings)
            {
                configurations.Add(key, ConfigurationManager.AppSettings[key]);
            }
            return new Configurations { AppSettings = configurations };
        }
    }
}
