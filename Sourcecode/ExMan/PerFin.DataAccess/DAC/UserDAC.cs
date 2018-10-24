using PerFin.Core;
using PerFin.Core.Constants;
using PerFin.Core.Contracts;
using PerFin.DataAccess.Base;
using PerFin.DataAccess.Core;
using PerFin.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PerFin.DataAccess.DAC
{
    public class UserDAC : EntityDACBase
    {

        public UserDAC(IAppSettings appSettings)
            :base(appSettings)
        { }

        public Task<OperationResult<List<ComponentType>>> GetAuthorizedComponentsForUser(string username)
        {
            try
            {
                SqlCommand command = GetDbSprocCommand(SPConstants.SP_FETCH_COMPONENTS_FOR_USER);
                command.Parameters.Add(CreateParameter("@Username", username));
                return Task.Run(() => OperationResult<List<ComponentType>>.ReturnSuccessResult(GetEntities<ComponentType>(ref command)));
            }
            catch (Exception ex)
            {
                return Task.Run(() => OperationResult<List<ComponentType>>.LogAndReturnFailureResult(ex));
            }
        }

        public Task<OperationResult<SessionInfo>> RegisterNewLogin(string username, string encryptedPassword, string deviceHash, DeviceType deviceType)
        {
            try
            {
                SqlCommand command = GetDbSprocCommand(SPConstants.SP_REGISTER_NEW_LOGIN);
                command.Parameters.Add(CreateParameter("@Username", username));
                command.Parameters.Add(CreateParameter("@PasswordHash", encryptedPassword));
                command.Parameters.Add(CreateParameter("@DeviceHash", deviceHash));
                command.Parameters.Add(CreateParameter("@DeviceTypeId", (int)deviceType));
                command.Parameters.Add(CreateOutputParameter("@SessionId", System.Data.SqlDbType.VarChar, 50));
                command.Parameters.Add(CreateOutputParameter("@ErrorCode", System.Data.SqlDbType.Int));

                return Task.Run(() =>
                {
                    DbOperationResult sqlDbOperationResult = GetDbOperationResult(ref command, DBConstants.SESSIONID);
                    SessionInfo sessionInfo = new SessionInfo(string.Empty, sqlDbOperationResult.StatusCode);
                    if (sessionInfo.ErrorCode == 0)
                    {
                        sessionInfo.SessionId = sqlDbOperationResult.Result.ToString();
                    }
                    return OperationResult<SessionInfo>.ReturnSuccessResult(sessionInfo);
                });
            }
            catch (Exception ex)
            {
                return Task.Run(() => OperationResult<SessionInfo>.LogAndReturnFailureResult(ex));
            }
        }

        public Task<OperationResult<SessionInfo>> LoginExistingUser(string username, string encryptedPassword, DeviceType deviceType, string deviceHash)
        {
            try
            {
                SqlCommand command = GetDbSprocCommand(SPConstants.SP_LOGIN);
                command.Parameters.Add(CreateParameter("@Username", username));
                command.Parameters.Add(CreateParameter("@PasswordHash", encryptedPassword));
                command.Parameters.Add(CreateParameter("@DeviceHash", deviceHash));
                command.Parameters.Add(CreateParameter("@DeviceTypeId", (int)deviceType));
                command.Parameters.Add(CreateOutputParameter("@SessionId", System.Data.SqlDbType.VarChar, 50));
                command.Parameters.Add(CreateOutputParameter("@ErrorCode", System.Data.SqlDbType.Int));

                return Task.Run(() =>
                {
                    DbOperationResult sqlDbOperationResult = GetDbOperationResult(ref command, DBConstants.SESSIONID);
                    SessionInfo sessionInfo = new SessionInfo(string.Empty, sqlDbOperationResult.StatusCode);
                    if (sessionInfo.ErrorCode == 0)
                    {
                        sessionInfo.SessionId = sqlDbOperationResult.Result.ToString();
                    }
                    return OperationResult<SessionInfo>.ReturnSuccessResult(sessionInfo);
                });
            }
            catch (Exception ex)
            {
                return Task.Run(() => OperationResult<SessionInfo>.LogAndReturnFailureResult(ex));
            }
        }

    }
}
