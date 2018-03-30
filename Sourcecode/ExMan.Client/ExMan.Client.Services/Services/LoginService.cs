using ExMan.Client.Services.Base;
using ExMan.Client.Services.Entities;
using ExMan.Client.Shared.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Services
{
    public class LoginService : ServiceBase
    {
        #region Fields & Properties

        private const string GRANT_TYPE_VALUE = "password";

        #endregion

        #region CTOR

        public LoginService(RestClient restClient) 
            : base(restClient)
        {
        }

        #endregion

        #region Methods

        public async Task<ResponseModel<string>> LoginAndFetchBearerToken(string username, string password)
        {
            ResponseModel<string> tokenResponse = null;
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters[LoginAPIConstants.USERNAME] = username;
                parameters[LoginAPIConstants.PASSWORD] = password;
                parameters[LoginAPIConstants.GRANT_TYPE] = GRANT_TYPE_VALUE;
                string requestURI = GenerateQueryStringFromParameters(parameters);
                ResponseModel<BearerToken> bearerTokenResponse =
                    await RestClientInstance.ExecuteLogin<BearerToken>(ConfigurationManager.AppSettings[ServiceConstants.APIEndPoint], requestURI);
                
                if (bearerTokenResponse != null && bearerTokenResponse.ServiceOperationResult == ServiceOperationResult.Success)
                {
                    if (bearerTokenResponse.ErrorCode != 0)
                    {
                        tokenResponse = new ResponseModel<string>
                        {
                            ServiceOperationResult = ServiceOperationResult.Success,
                            Data = bearerTokenResponse.Data.AccessToken
                        };
                    }
                    else
                    {
                        tokenResponse = new ResponseModel<string>
                        {
                            ServiceOperationResult = ServiceOperationResult.Failure
                        };
                    }
                }
                else
                {
                    tokenResponse = new ResponseModel<string> { ServiceOperationResult = bearerTokenResponse.ServiceOperationResult };
                }
            }
            catch (ServiceAccessException)
            {
                tokenResponse = new ResponseModel<string> { ServiceOperationResult = ServiceOperationResult.Failure };
            }
            catch (Exception ex)
            {
                tokenResponse = new ResponseModel<string> { ServiceOperationResult = ServiceOperationResult.Failure };
            }
            return tokenResponse;
        }

        #endregion

    }
}
