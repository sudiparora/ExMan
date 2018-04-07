using ExMan.Client.Core;
using ExMan.Client.Core.ExceptionHandling;
using ExMan.Client.Services.Base;
using ExMan.Client.Services.Entities;
using ExMan.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Services.Services
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

        public async Task<ResponseModel<BearerTokenDTO>> LoginAndFetchBearerToken(string username, string password)
        {
            ResponseModel<BearerTokenDTO> tokenResponse = null;
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters[LoginAPIConstants.USERNAME] = username;
                parameters[LoginAPIConstants.PASSWORD] = password;
                parameters[LoginAPIConstants.GRANT_TYPE] = GRANT_TYPE_VALUE;
                string requestURI = GenerateQueryStringFromParameters(parameters);
                ResponseModel<BearerToken> bearerTokenResponse = await RestClientInstance.ExecuteLogin<BearerToken>(
                    LocatorService.ConfigurationManager.GetConfigurations().AppSettings[ServiceConstants.APIEndPoint].ToString(), requestURI);

                if (bearerTokenResponse != null && bearerTokenResponse.ServiceOperationResult == ServiceOperationResult.Success)
                {
                    if (bearerTokenResponse.ErrorCode == 0)
                    {
                        tokenResponse = new ResponseModel<BearerTokenDTO>
                        {
                            ServiceOperationResult = ServiceOperationResult.Success,
                            Data = new BearerTokenDTO
                            {
                                AccessToken = bearerTokenResponse.Data.AccessToken,
                                ExpiryDate = DateTime.Now + new TimeSpan(14, 0, 0, 0)
                            }
                        };
                    }
                    else
                    {
                        tokenResponse = new ResponseModel<BearerTokenDTO>
                        {
                            ServiceOperationResult = ServiceOperationResult.Failure
                        };
                    }
                }
                else
                {
                    tokenResponse = new ResponseModel<BearerTokenDTO> { ServiceOperationResult = bearerTokenResponse.ServiceOperationResult };
                }
            }
            catch (ServiceAccessException)
            {
                tokenResponse = new ResponseModel<BearerTokenDTO> { ServiceOperationResult = ServiceOperationResult.Failure };
            }
            catch (Exception ex)
            {
                tokenResponse = new ResponseModel<BearerTokenDTO> { ServiceOperationResult = ServiceOperationResult.Failure };
            }
            return tokenResponse;
        }

        #endregion

    }
}
