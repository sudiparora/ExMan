using PerFin.Core;
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

    }
}
