using System;

namespace PerFin.Core.Contracts
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
