using ExMan.Client.Services.Base;

namespace ExMan.Desktop.Client.Core
{
    public class DesktopUserSettingsManager : IUserSettingsManager
    {
        public string GetBearerToken()
        {
            return UserSettings.Default.BearerToken;
        }
        
    }
}
