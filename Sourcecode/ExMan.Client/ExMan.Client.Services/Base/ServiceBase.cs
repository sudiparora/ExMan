using ExMan.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Services.Base
{
    public class ServiceBase
    {

        private RestClient restClient;

        public ServiceBase(RestClient restClient)
        {
            this.restClient = restClient;
        }

        internal RestClient RestClientInstance
        {
            get { return restClient; }
        }

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
