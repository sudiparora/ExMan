using PerFin.Core.Contracts;
using PerFin.Core.Services;
using PerFin.Entities.Authentication;
using PerFin.Services.Base;
using System;
using System.Threading.Tasks;

namespace PerFin.Services
{
    public class LoginService : ServiceBase
    {
        public LoginService(RestClient restClient, ILogger logger) 
            : base(restClient, logger)
        { }

        public async Task<ResponseModel<BearerTokenInfo>> LoginAndFetchBearerToken(string username, string encryptedPassword)
        {
            ResponseModel<BearerTokenInfo> tokenResponse = null;
            try
            {
                ResponseModel<BearerTokenInfo> bearerTokenResponse = await RestClientInstance.ExecuteLogin<BearerTokenInfo>(
                    string.Empty,username, encryptedPassword);

                if (bearerTokenResponse != null && bearerTokenResponse.ServiceOperationResult == ServiceOperationResult.Success)
                {
                    if (bearerTokenResponse.ErrorCode == 0)
                    {
                        tokenResponse = new ResponseModel<BearerTokenInfo>
                        {
                            ServiceOperationResult = ServiceOperationResult.Success,
                            Data = bearerTokenResponse.Data
                        };
                        LoggerInstance.LogInfo("New Access Token Generated for {0} at {1}", username, DateTime.Now.ToString());
                    }
                    else
                    {
                        tokenResponse = new ResponseModel<BearerTokenInfo>
                        {
                            ServiceOperationResult = ServiceOperationResult.Failure
                        };
                    }
                }
                else
                {
                    tokenResponse = new ResponseModel<BearerTokenInfo> { ServiceOperationResult = bearerTokenResponse.ServiceOperationResult };
                }
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Login API failed", ex);
                tokenResponse = new ResponseModel<BearerTokenInfo> { ServiceOperationResult = ServiceOperationResult.Error };
            }
            return tokenResponse;
        }

    }
}
