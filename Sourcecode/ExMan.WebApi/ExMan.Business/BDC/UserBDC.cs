using AutoMapper;
using ExMan.DataAccess.DAC;
using ExMan.DTO;
using ExMan.Entities;
using ExMan.Shared.Core;
using System;
using System.Collections.Generic;

namespace ExMan.Business.BDC
{
    public class UserBDC : BDCBase
    {
        public List<ComponentTypeDTO> GetAuthorizedComponentsForUser(string username)
        {
            List<ComponentTypeDTO> componentTypes = new List<ComponentTypeDTO>();
            try
            {
                OperationResult<List<ComponentType>> componentTypesResult = DependencyFactory.Resolve<UserDAC>().GetAuthorizedComponentsForUser(username);
                if (componentTypesResult.IsSuccessful)
                {
                    componentTypes = Mapper.Map<List<ComponentType>, List<ComponentTypeDTO>>(componentTypesResult.Result);
                }
                else
                { }
            }
            catch(Exception ex)
            {
                componentTypes = null;
            }
            return componentTypes;
        }
    }
}
