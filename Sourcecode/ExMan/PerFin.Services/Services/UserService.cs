using PerFin.Business.BDC;
using PerFin.Core;
using PerFin.Core.Contracts;
using PerFin.Core.Services;
using PerFin.Entities.Authentication;
using PerFin.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerFin.Services
{
    public class UserService : ServiceBase
    {

        #region CTOR

        public UserService(ILogger logger, UserBDC userBDC)
            : base(logger)
        {
            UserBDCInstance = userBDC;
        }

        #endregion
        internal UserBDC UserBDCInstance { get; }

        public async Task<ResponseModel<List<ComponentType>>> GetAvailableComponentTypes(string username)
        {
            ResponseModel<List<ComponentType>> componentTypes = null;
            try
            {
                OperationResult<List<ComponentType>> componentTypesResponse = await UserBDCInstance.GetAuthorizedComponentsForUser(username);
                if (componentTypesResponse.IsSuccessful)
                {
                    componentTypes = new ResponseModel<List<ComponentType>>
                    {
                        ServiceOperationResult = ServiceOperationResult.Success,
                        Data = componentTypesResponse.Result
                    };
                }
            }
            catch (Exception ex)
            {
                LoggerInstance.LogError("Fetching Component Types for User failed", ex);
                componentTypes = new ResponseModel<List<ComponentType>>
                {
                    ServiceOperationResult = ServiceOperationResult.Error
                };
            }
            return componentTypes;
        }

    }
}
