using ExMan.DataAccess.DAC;
using Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExMan.AWS.WebApi.Core
{
    public class UnityConfig
    {
        public static void RegisterObjects()
        {
            DependencyFactory.Container.RegisterType<UserDAC, UserDAC>();
        }
    }
}
