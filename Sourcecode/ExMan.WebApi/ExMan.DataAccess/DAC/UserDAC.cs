using ExMan.DataAccess.Base;
using ExMan.DataAccess.Core;
using ExMan.Entities;
using ExMan.Shared.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ExMan.DataAccess.DAC
{
    public class UserDAC: EntityDACBase
    {
        public OperationResult<List<ComponentType>> GetAuthorizedComponentsForUser(string username)
        {
            try
            {
                SqlCommand command = GetDbSprocCommand(SPConstants.SP_FETCH_COMPONENTS_FOR_USER);
                command.Parameters.Add(CreateParameter("@Username", username));
                List<ComponentType> componentTypes = GetEntities<ComponentType>(ref command);
                return OperationResult<List<ComponentType>>.ReturnSuccessResult(componentTypes);
            }
            catch (Exception ex)
            {
                return OperationResult<List<ComponentType>>.LogAndReturnFailureResult(ex);
            }
        }

    }
}
