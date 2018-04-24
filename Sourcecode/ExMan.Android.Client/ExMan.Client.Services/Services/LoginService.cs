using ExMan.Client.Core;
using ExMan.Client.Services.Base;
using ExMan.Client.Services.Entities;
using ExMan.Shared.DTO;
using System;
using System.Threading.Tasks;

namespace ExMan.Client.Services
{
    public class LoginService : ServiceBase
    {

        #region CTOR

        public LoginService(RestClient restClient)
            : base(restClient)
        { }

        #endregion

        #region Methods

        public async Task<ResponseModel<BearerTokenDTO>> LoginAndFetchBearerToken(string username, string encryptedPassword)
        {
            ResponseModel<BearerTokenDTO> tokenResponse = null;
            try
            {
                ResponseModel<BearerToken> bearerTokenResponse = await RestClientInstance.ExecuteLogin<BearerToken>(
                    LocatorService.ConfigurationManager.GetConfigurations().AppSettings[ServiceConstants.APIEndPoint].ToString(),
                    username, encryptedPassword);

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
                        LocatorService.Logger.LogInfo("New Access Token Generated for {0} at {1}", username, DateTime.Now.ToString());
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
            catch (Exception ex)
            {
                LocatorService.Logger.LogError("Login API failed", ex);
                tokenResponse = new ResponseModel<BearerTokenDTO> { ServiceOperationResult = ServiceOperationResult.Error };
            }
            return tokenResponse;
        }

        #endregion

    }
}
