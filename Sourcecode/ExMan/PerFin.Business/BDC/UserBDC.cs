using PerFin.Core;
using PerFin.Core.Constants;
using PerFin.Core.Contracts;
using PerFin.DataAccess.DAC;
using PerFin.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerFin.Business.BDC
{
    public class UserBDC: BDCBase
    {

        public UserBDC(IAppSettings appSettings, ILogger logger, UserDAC userDAC)
            :base(appSettings, logger)
        {
            UserDACInstance = userDAC;
        }


        internal UserDAC UserDACInstance { get; }

        public async Task<OperationResult<List<ComponentType>>> GetAuthorizedComponentsForUser(string username, string sessionId)
        {
            try
            {
                return OperationResult<List<ComponentType>>.ReturnOperationResult(await UserDACInstance.GetAuthorizedComponentsForUser(username, sessionId));
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Error in getting authorized components for user", ex);
                return OperationResult<List<ComponentType>>.ReturnFailureResult();
            }
        }

        public async Task<OperationResult<SessionInfo>> RegisterNewLogin(string username, string encryptedPassword, string deviceHash, DeviceType deviceType)
        {
            try
            {
                DbOperationResult<string> registerNewLoginResult = await UserDACInstance.RegisterNewLogin(username, encryptedPassword, deviceHash, deviceType);
                OperationResult<SessionInfo> sessionInfoResult = default(OperationResult<SessionInfo>);
                sessionInfoResult.IsSuccessful = registerNewLoginResult.IsSuccessful;
                if (sessionInfoResult.IsSuccessful)
                {
                    SessionInfo sessionInfo = default(SessionInfo);
                    sessionInfo.SessionId = registerNewLoginResult.Result;
                    sessionInfoResult.Result = sessionInfo;
                }
                else
                {
                    sessionInfoResult.ErrorCode = registerNewLoginResult.StatusCode;
                }
                return sessionInfoResult;
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Error in logging in registering new login", ex);
                return OperationResult<SessionInfo>.ReturnFailureResult();
            }
        }

        public async Task<OperationResult<SessionInfo>> LoginExistingUser(string username, string encryptedPassword, string deviceHash, DeviceType deviceType)
        {
            try
            {
                DbOperationResult<string> registerNewLoginResult = await UserDACInstance.LoginExistingUser(username, encryptedPassword, deviceType, deviceHash);
                OperationResult<SessionInfo> sessionInfoResult = new OperationResult<SessionInfo>
                {
                    IsSuccessful = registerNewLoginResult.IsSuccessful
                };
                if (sessionInfoResult.IsSuccessful)
                {
                    SessionInfo sessionInfo = new SessionInfo();
                    sessionInfo.SessionId = registerNewLoginResult.Result;
                    sessionInfoResult.Result = sessionInfo;
                }
                else
                {
                    sessionInfoResult.ErrorCode = registerNewLoginResult.StatusCode;
                }
                return sessionInfoResult;
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Error in logging in existing user", ex);
                return OperationResult<SessionInfo>.ReturnFailureResult();
            }
        }
    }
}
