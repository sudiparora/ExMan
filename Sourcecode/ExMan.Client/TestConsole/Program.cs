using ExMan.Client.Services;
using ExMan.Client.Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LogFactory.Instance.LogInfo("App start");
            LogFactory.Instance.LogError("Log Exception:", new Exception());
            LoginService loginService = new LoginService(new RestClient());
            loginService.LoginAndFetchBearerToken("sudip.arora@gmail.com", "Ggn@1234").GetAwaiter().OnCompleted(
                () =>
                {
                    Console.WriteLine("Completed");
                    Console.ReadLine();
                }
                );

        }
    }
}
