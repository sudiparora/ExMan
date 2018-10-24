using PerFin.Business.BDC;
using PerFin.Core;
using PerFin.Core.Constants;
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
        UserBDC UserBDCInstance { get; }
        IAppSettings AppSettingsInstance { get; }

        public LoginService(ILogger logger, IAppSettings iAppSettings, UserBDC userBDC)
            : base(logger)
        {
            AppSettingsInstance = iAppSettings;
            UserBDCInstance = userBDC;
        }

        public async Task<ResponseModel<SessionInfo>> RegisterNewLogin(string username, string encryptedPassword, string deviceHash, DeviceType deviceType)
        {
            ResponseModel<SessionInfo> registerNewLoginResponse = null;
            try
            {
                OperationResult<SessionInfo> sessionInfoResponse = await UserBDCInstance.RegisterNewLogin(username, encryptedPassword, deviceHash, deviceType);
                if (sessionInfoResponse.IsSuccessful)
                {
                    registerNewLoginResponse = new ResponseModel<SessionInfo>
                    {
                        ServiceOperationResult = ServiceOperationResult.Success,
                        Data = sessionInfoResponse.Result
                    };
                    LoggerInstance.LogInfo("New Session Generated for {0} at {1}", username, DateTime.Now.ToString());
                }
                else
                {
                    registerNewLoginResponse = new ResponseModel<SessionInfo>
                    {
                        ServiceOperationResult = ServiceOperationResult.Failure
                    };
                }
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Register New Login failed", ex);
                registerNewLoginResponse = new ResponseModel<SessionInfo> { ServiceOperationResult = ServiceOperationResult.Error };
            }
            return registerNewLoginResponse;
        }

        public async Task<ResponseModel<SessionInfo>> LoginExistingUser(string username, string encryptedPassword, string deviceHash, DeviceType deviceType)
        {
            ResponseModel<SessionInfo> loginExistingUserResponse = null;
            try
            {
                OperationResult<SessionInfo> sessionInfoResponse = await UserBDCInstance.LoginExistingUser(username, encryptedPassword, deviceHash, deviceType);
                if (sessionInfoResponse.IsSuccessful)
                {
                    loginExistingUserResponse = new ResponseModel<SessionInfo>
                    {
                        ServiceOperationResult = ServiceOperationResult.Success,
                        Data = sessionInfoResponse.Result
                    };
                    LoggerInstance.LogInfo("New Session Generated for {0} at {1}", username, DateTime.Now.ToString());
                }
                else
                {
                    loginExistingUserResponse = new ResponseModel<SessionInfo>
                    {
                        ServiceOperationResult = ServiceOperationResult.Failure
                    };
                }
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Login Existing User failed", ex);
                loginExistingUserResponse = new ResponseModel<SessionInfo> { ServiceOperationResult = ServiceOperationResult.Error };
            }
            return loginExistingUserResponse;
        }
    }
}

