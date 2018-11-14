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

        public UserDAC(IAppSettings appSettings, ILogger logger)
            :base(appSettings, logger)
        { }

        public Task<DbOperationResult<List<ComponentType>>> GetAuthorizedComponentsForUser(string username, string sessionId)
        {
            try
            {
                SqlCommand command = GetDbSprocCommand(SPConstants.SP_FETCH_COMPONENTS_FOR_USER);
                command.Parameters.Add(CreateParameter("@Username", username));
                command.Parameters.Add(CreateParameter("@SessionId", sessionId));
                command.Parameters.Add(CreateOutputParameter("@ErrorCode", System.Data.SqlDbType.Int));
                return Task.Run(() => GetEntities<ComponentType>(ref command));
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Error in getting authorized components for user", ex);
                return Task.Run(() => DbOperationResult<List<ComponentType>>.ReturnFailureResult());
            }
        }

        //public Task<OperationResult<List<ComponentType>>> GetAuthorizedComponentsForUser(string username, string sessionId)
        //{
        //    try
        //    {
        //        SqlCommand command = GetDbSprocCommand(SPConstants.SP_FETCH_COMPONENTS_FOR_USER);
        //        command.Parameters.Add(CreateParameter("@Username", username));
        //        command.Parameters.Add(CreateParameter("@SessionId", sessionId));
        //        command.Parameters.Add(CreateOutputParameter("@ErrorCode", System.Data.SqlDbType.Int));

        //        return Task.Run(() => 
        //        {
        //            DbOperationResult dbOperationResult = GetEntities<ComponentType>(ref command);
        //            List<ComponentType> componentTypes = null;
        //            if (dbOperationResult.IsSuccessful)
        //            {
        //                componentTypes = (List<ComponentType>)dbOperationResult.Result;
        //                return OperationResult<List<ComponentType>>.ReturnSuccessResult(componentTypes);
        //            }
        //            else
        //            {
        //                return OperationResult<List<ComponentType>>.ReturnFailureResult();
        //            }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Task.Run(() => OperationResult<List<ComponentType>>.LogAndReturnFailureResult(ex));
        //    }
        //}

        public Task<DbOperationResult<string>> RegisterNewLogin(string username, string encryptedPassword, string deviceHash, DeviceType deviceType)
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
                return Task.Run(() => GetDbOperationResult<string>(ref command, DBConstants.SESSIONID));
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Error in registering new Login", ex);
                return Task.Run(() => DbOperationResult<string>.ReturnFailureResult());
            }
        }

        public Task<DbOperationResult<string>> LoginExistingUser(string username, string encryptedPassword, DeviceType deviceType, string deviceHash)
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
                return Task.Run(() => GetDbOperationResult<string>(ref command, DBConstants.SESSIONID));
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Error in logging in existing user", ex);
                return Task.Run(() => DbOperationResult<string>.ReturnFailureResult());
            }
        }

    }
}
