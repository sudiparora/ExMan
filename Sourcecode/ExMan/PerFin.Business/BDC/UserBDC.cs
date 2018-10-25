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

        public UserBDC(IAppSettings appSettings, UserDAC userDAC)
            :base(appSettings)
        {
            UserDACInstance = userDAC;
        }


        internal UserDAC UserDACInstance { get; }

        public async Task<OperationResult<List<ComponentType>>> GetAuthorizedComponentsForUser(string username, string sessionId)
        {
            try
            {
                OperationResult<List<ComponentType>> componentTypesResult = await UserDACInstance.GetAuthorizedComponentsForUser(username, sessionId);
                if (componentTypesResult.IsSuccessful)
                {
                    return OperationResult<List<ComponentType>>.ReturnSuccessResult(componentTypesResult.Result);
                }
                else
                {
                    return OperationResult<List<ComponentType>>.ReturnFailureResult();
                }
            }
            catch (Exception ex)
            {
                return OperationResult<List<ComponentType>>.LogAndReturnFailureResult(ex);
            }
        }

        public async Task<OperationResult<SessionInfo>> RegisterNewLogin(string username, string encryptedPassword, string deviceHash, DeviceType deviceType)
        {
            try
            {
                OperationResult<SessionInfo> registerNewLoginResult = await UserDACInstance.RegisterNewLogin(username, encryptedPassword, deviceHash, deviceType);
                if (registerNewLoginResult.IsSuccessful && registerNewLoginResult.Result.ErrorCode == 0)
                {
                    return OperationResult<SessionInfo>.ReturnSuccessResult(registerNewLoginResult.Result);
                }
                else
                {
                    return OperationResult<SessionInfo>.ReturnFailureResult();
                }
            }
            catch (Exception ex)
            {
                return OperationResult<SessionInfo>.LogAndReturnFailureResult(ex);
            }
        }

        public async Task<OperationResult<SessionInfo>> LoginExistingUser(string username, string encryptedPassword, string deviceHash, DeviceType deviceType)
        {
            try
            {
                OperationResult<SessionInfo> registerNewLoginResult = await UserDACInstance.LoginExistingUser(username, encryptedPassword, deviceType, deviceHash);
                if (registerNewLoginResult.IsSuccessful && registerNewLoginResult.Result.ErrorCode == 0)
                {
                    return OperationResult<SessionInfo>.ReturnSuccessResult(registerNewLoginResult.Result);
                }
                else
                {
                    return OperationResult<SessionInfo>.ReturnFailureResult();
                }
            }
            catch (Exception ex)
            {
                return OperationResult<SessionInfo>.LogAndReturnFailureResult(ex);
            }
        }
    }
}
