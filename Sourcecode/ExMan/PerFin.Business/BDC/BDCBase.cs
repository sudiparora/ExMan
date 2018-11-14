using PerFin.Core.Contracts;

namespace PerFin.Business.BDC
{
    public abstract class BDCBase
    {

        public BDCBase(IAppSettings appSettings, ILogger logger)
        {
            AppSettingsInstance = appSettings;
            LoggerInstance = logger;
        }

        internal IAppSettings AppSettingsInstance { get; }
        internal ILogger LoggerInstance { get; }

    }
}
