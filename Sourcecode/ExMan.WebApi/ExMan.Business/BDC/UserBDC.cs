using ExMan.Business.DTO;
using ExMan.DataAccess.DAC;
using ExMan.Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Business.BDC
{
    public class UserBDC : BDCBase
    {
        public OperationResult<List<ComponentTypeDTO>> GetAuthorizedComponentsForUser(string username)
        {
            DependencyFactory.Resolve<UserDAC>().GetAuthorizedComponentsForUser(username);
        }
    }
}
