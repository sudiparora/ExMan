using ExMan.Client.Services.Base;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ExMan.Desktop.Client.Core
{
    public sealed class DesktopConfigurationManager : IConfigurationManager
    {

        /// <summary>
        /// http://geekswithblogs.net/BlackRabbitCoder/archive/2010/05/19/c-system.lazylttgt-and-the-singleton-design-pattern.aspx
        /// The .net provided lazy initialization and singleton design pattern usage
        /// </summary>
        private static readonly Lazy<DesktopConfigurationManager> configurationManagerInstance
            = new Lazy<DesktopConfigurationManager>(() => new DesktopConfigurationManager());

        private Configurations desktopConfigurations;

        internal static DesktopConfigurationManager ConfigurationManagerInstance
        {
            get
            {
                return configurationManagerInstance.Value;
            }
        }

        public Configurations DesktopConfigurations
        {
            get
            {
                if (desktopConfigurations == null)
                {
                    Dictionary<string, object> configurations = new Dictionary<string, object>();
                    foreach (string key in ConfigurationManager.AppSettings)
                    {
                        configurations.Add(key, ConfigurationManager.AppSettings[key]);
                    }
                    desktopConfigurations = new Configurations { AppSettings = configurations };
                }
                return desktopConfigurations;
            }
        }

        public Configurations GetConfigurations()
        {
            return DesktopConfigurations;
        }
    }
}
