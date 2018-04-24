using System.Web.Http;

namespace ExMan.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    { }
}
