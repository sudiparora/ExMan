using ExMan.Business.BDC;
using ExMan.Shared.Core;
using ExMan.Shared.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace ExMan.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Component")]
    public class ComponentController : ApiController
    {

        public List<ComponentTypeDTO> GetAuthorizedComponentsForUser()
        {
            return DependencyFactory.Resolve<UserBDC>().GetAuthorizedComponentsForUser(RequestContext.Principal.Identity.Name).Result;
        }
    }
}
