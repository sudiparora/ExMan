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
        private const string AWSUSERPOOLID = "USERPOOL_ID";
        private const string AWSCLIENTID = "CLIENT_ID";

        public string DbConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DATABASECONNECTIONSTRING].ConnectionString;
            }
        }

        public string AWSUserPoolId
        {
            get
            {
                return ConfigurationManager.AppSettings[AWSUSERPOOLID];
            }
        }

        public string AWSClientId
        {
            get
            {
                return ConfigurationManager.AppSettings[AWSCLIENTID];
            }
        }
    }
}
