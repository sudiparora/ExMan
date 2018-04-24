using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Services.Base
{
    public interface ILogger
    {
        void LogDebug(string message, params string[] values);
        void LogInfo(string message, params string[] values);
        void LogWarning(string message, params string[] values);
        void LogError(string message, params string[] values);
        void LogError(string message, Exception ex);

    }
}
