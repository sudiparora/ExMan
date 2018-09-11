using PerFin.Core.Contracts;

namespace PerFin.Business.BDC
{
    public abstract class BDCBase
    {

        public BDCBase(IAppSettings appSettings)
        {
            AppSettingsInstance = appSettings;
        }

        internal IAppSettings AppSettingsInstance { get; }

    }
}
