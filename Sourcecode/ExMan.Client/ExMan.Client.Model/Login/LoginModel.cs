using ExMan.Client.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Model.Login
{
    public class LoginModel: ModelBase
    {

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
