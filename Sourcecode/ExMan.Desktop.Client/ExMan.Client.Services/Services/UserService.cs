using ExMan.Client.Core;
using ExMan.Client.Model.Components;
using ExMan.Client.Services.Base;
using ExMan.Client.Services.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Services
{
    public class UserService : ServiceBase
    {

        #region CTOR

        public UserService(RestClient restClient) 
            : base(restClient)
        {
        }

        #endregion

        public async Task<ResponseModel<List<ComponentTypeModel>>> GetAvailableComponentTypes(string username)
        {
            ResponseModel<List<ComponentTypeModel>> componentTypes = null;
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters[UserAPIConstants.USERNAME] = username;
                string requestURI = UserAPIConstants.GETCOMPONENTTYPESAPI + GenerateQueryStringFromParameters(parameters);
                ResponseModel<List<ComponentType>> componentTypesResponse =
                    await RestClientInstance.Execute<List<ComponentType>>(ConfigurationManager.AppSettings[ServiceConstants.APIEndPoint], requestURI);

                if (componentTypesResponse.ServiceOperationResult == ServiceOperationResult.Success && componentTypesResponse.Data != null)
                {
                    componentTypes = new ResponseModel<List<ComponentTypeModel>>
                    {
                        ServiceOperationResult = ServiceOperationResult.Success
                    };
                }
            }
            catch (Exception ex)
            { }
            return componentTypes;
        }
    }
}
