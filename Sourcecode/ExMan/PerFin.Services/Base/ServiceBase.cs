using PerFin.Core.Contracts;
using System.Collections.Generic;
using System.Text;

namespace PerFin.Services.Base
{
    public class ServiceBase
    {

        public ServiceBase(ILogger logger)
        {
            LoggerInstance = logger;
        }

        public ServiceBase(RestClient restClient, ILogger logger)
        {
            RestClientInstance = restClient;
            LoggerInstance = logger;
        }

        internal RestClient RestClientInstance { get; }
        internal ILogger LoggerInstance { get; }

        internal string GenerateQueryStringFromParameters(Dictionary<string, string> parameters)
        {
            var query = new StringBuilder();
            foreach (KeyValuePair<string, string> item in parameters)
            {
                query.AppendFormat("{0}={1}&", item.Key, item.Value);
            }
            return query.ToString().TrimEnd(' ').TrimEnd('&');
        }

    }
}
