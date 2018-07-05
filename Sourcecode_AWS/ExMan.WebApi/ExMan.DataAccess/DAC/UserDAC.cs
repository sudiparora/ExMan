using ExMan.DataAccess.Base;
using ExMan.DataAccess.Core;
using ExMan.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ExMan.DataAccess.DAC
{
    public class UserDAC : EntityDACBase
    {

        public List<ComponentType> GetAuthorizedComponentsForUser(string usersub)
        {
            List<ComponentType> componentTypes = null;
            try
            {
                SqlCommand command = GetDbSprocCommand(SPConstants.SP_FETCH_COMPONENTS_FOR_USER);
                command.Parameters.Add(CreateParameter("@Usersub", usersub));
                componentTypes = GetEntities<ComponentType>(ref command);
                //return OperationResult<List<ComponentType>>.ReturnSuccessResult(componentTypes);
            }
            catch (Exception ex)
            {
                //return OperationResult<List<ComponentType>>.LogAndReturnFailureResult(ex);
            }
            return componentTypes;
        }

    }
}
