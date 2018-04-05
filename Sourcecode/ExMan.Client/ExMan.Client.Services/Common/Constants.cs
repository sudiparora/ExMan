using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Services
{

    public struct ServiceConstants
    {
        public const string APIEndPoint = "ExManApiEndPoint";
    }

    public struct LoginAPIConstants
    {

        public const string LOGINWITHBEARERTOKENAPI = "/Token?";
        public const string USERNAME = "username";
        public const string PASSWORD = "password";
        public const string GRANT_TYPE = "grant_type";
    }

    public struct UserAPIConstants
    {
        public const string GETCOMPONENTTYPESAPI = "api/user/GetAuthroizedComponentsForUser?";
        public const string USERNAME = "username";

    }
}
