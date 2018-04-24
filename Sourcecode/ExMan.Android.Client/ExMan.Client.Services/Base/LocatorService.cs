using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ExMan.Client.Services.Base
{
    public class LocatorService
    {

        public LocatorService()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }

        public static IConfigurationManager ConfigurationManager
        {
            get
            {
                return SimpleIoc.Default.GetInstance<IConfigurationManager>();
            }
        }

        public static ILogger Logger
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ILogger>();
            }
        }

        public static IUserSettingsManager UserSettingsManager
        {
            get
            {
                return SimpleIoc.Default.GetInstance<IUserSettingsManager>();
            }
        }

    }
}
