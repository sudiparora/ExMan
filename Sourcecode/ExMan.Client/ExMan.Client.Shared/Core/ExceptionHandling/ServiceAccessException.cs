using ExMan.Client.Shared.Core.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Shared.Core
{
    public class ServiceAccessException: BaseException
    {
        public override void SetExceptionType()
        {
            ExceptionType = ExceptionType.ServiceAccessException;
        }
    }
}
