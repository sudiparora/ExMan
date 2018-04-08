using ExMan.Client.Core;
using ExMan.Client.Services.Base;
using ExMan.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExMan.Client.Services
{
    public class UserService : ServiceBase
    {

        #region CTOR

        public UserService(RestClient restClient) : base(restClient)
        {
        }

        #endregion

        public async Task<ResponseModel<List<ComponentTypeDTO>>> GetAvailableComponentTypes()
        {
            ResponseModel<List<ComponentTypeDTO>> componentTypes = null;
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                string requestURI = UserAPIConstants.GETCOMPONENTTYPESAPI + GenerateQueryStringFromParameters(parameters);

                ResponseModel<List<ComponentTypeDTO>> componentTypesResponse = await RestClientInstance.Execute<List<ComponentTypeDTO>>
                    (LocatorService.ConfigurationManager.GetConfigurations().AppSettings[ServiceConstants.APIEndPoint].ToString(), requestURI);

                if (componentTypesResponse.ServiceOperationResult == ServiceOperationResult.Success && componentTypesResponse.Data != null)
                {
                    componentTypes = new ResponseModel<List<ComponentTypeDTO>>
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
