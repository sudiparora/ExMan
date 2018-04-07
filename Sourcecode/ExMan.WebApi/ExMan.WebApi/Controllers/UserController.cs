using ExMan.Business.BDC;
using ExMan.Shared.DTO;
using ExMan.Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExMan.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {

        public OperationResult<List<ComponentTypeDTO>> GetAuthroizedComponentsForUser(string username)
        {
            return DependencyFactory.Resolve<UserBDC>().GetAuthorizedComponentsForUser(username);
        }

    }
}
