using ExMan.Client.Services.Base;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Desktop.Client.Core
{
    public class DesktopLocatorService: LocatorService
    {

        public DesktopLocatorService()
        {
            SimpleIoc.Default.Register<IConfigurationManager, DesktopConfigurationManager>();
            SimpleIoc.Default.Register<ILogger, DesktopLogger>();
            SimpleIoc.Default.Register<IUserSettingsManager, DesktopUserSettingsManager>();
        }

    }
}
