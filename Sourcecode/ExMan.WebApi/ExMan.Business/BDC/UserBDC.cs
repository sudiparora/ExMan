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
        public OperationResult<List<ComponentTypeDTO>> GetAuthorizedComponentsForUser(string username)
        {
            try
            {
                OperationResult<List<ComponentType>> componentTypesResult = DependencyFactory.Resolve<UserDAC>().GetAuthorizedComponentsForUser(username);
                if (componentTypesResult.IsSuccessful)
                {
                    return OperationResult<List<ComponentTypeDTO>>.ReturnSuccessResult
                        (Mapper.Map<List<ComponentType>, List<ComponentTypeDTO>>(componentTypesResult.Result));
                }
                else
                {
                    return OperationResult<List<ComponentTypeDTO>>.ReturnFailureResult();
                }
            }
            catch(Exception ex)
            {
                return OperationResult<List<ComponentTypeDTO>>.LogAndReturnFailureResult(ex);
            }
        }
    }
}
