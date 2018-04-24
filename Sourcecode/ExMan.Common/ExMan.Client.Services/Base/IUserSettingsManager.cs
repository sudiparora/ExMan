using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Services.Base
{
    public interface IUserSettingsManager
    {
        string GetBearerToken();
        //void RefreshBearerToken();
    }

    public class Settings
    {
        public Dictionary<string, string> UserSettings;
    }
}
