using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Shared.Core
{
    public sealed class LogFactory
    {

        #region Fields & Properties

        /// <summary>
        /// http://geekswithblogs.net/BlackRabbitCoder/archive/2010/05/19/c-system.lazylttgt-and-the-singleton-design-pattern.aspx
        /// The .net provided lazy initialization and singleton design pattern usage
        /// </summary>
        private static readonly Lazy<LogFactory> logFactoryInstance
            = new Lazy<LogFactory>(() => new LogFactory());

        private static Logger Logger = LogManager.GetCurrentClassLogger();

        public static LogFactory Instance
        {
            get
            {
                return logFactoryInstance.Value;
            }
        }

        #endregion

        #region Methods

        public void LogDebug(string message, params string[] values)
        {
            if (Logger.IsDebugEnabled)
            {
                try
                {
                    string messageWithParams = message;
                    if (values.Any())
                    {
                        messageWithParams = string.Format(message, values);
                    }
                    Logger.Debug(messageWithParams);
                }
                catch (Exception)
                { }
            }
        }

        public void LogInfo(string message, params string[] values)
        {
            if (Logger.IsInfoEnabled)
            {
                try
                {
                    string messageWithParams = message;
                    if (values.Any())
                    {
                        messageWithParams = string.Format(message, values);
                    }
                    Logger.Info(messageWithParams);
                }
                catch (Exception)
                { }
            }
        }

        public void LogWarning(string message, params string[] values)
        {
            if (Logger.IsWarnEnabled)
            {
                try
                {
                    string messageWithParams = message;
                    if (values.Any())
                    {
                        messageWithParams = string.Format(message, values);
                    }
                    Logger.Warn(messageWithParams);
                }
                catch (Exception)
                { }
            }
        }

        public void LogError(string message, params string[] values)
        {
            if (Logger.IsErrorEnabled)
            {
                try
                {
                    string messageWithParams = message;
                    if (values.Any())
                    {
                        messageWithParams = string.Format(message, values);
                    }
                    Logger.Error(messageWithParams);
                }
                catch (Exception)
                { }
            }
        }

        public void LogError(string message, Exception ex)
        {
            if (Logger.IsErrorEnabled)
            {
                try
                {
                    Logger.Error(ex, message);
                }
                catch (Exception)
                { }
            }
        }

        #endregion

    }
}
