using PerFin.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerFin.Desktop.Core
{
    public class DesktopAppSettings : IAppSettings
    {

        private const string DATABASECONNECTIONSTRING = "SqlDataConString";

        public string DbConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DATABASECONNECTIONSTRING].ConnectionString;
            }
        }
    }
}
