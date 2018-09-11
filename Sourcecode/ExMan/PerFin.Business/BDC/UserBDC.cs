using PerFin.Core;
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

        public async Task<OperationResult<List<ComponentType>>> GetAuthorizedComponentsForUser(string username)
        {
            try
            {
                OperationResult<List<ComponentType>> componentTypesResult = await UserDACInstance.GetAuthorizedComponentsForUser(username);
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

    }
}
