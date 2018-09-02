using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExMan.AWS.WebApi.Core;
using ExMan.DataAccess.DAC;
using ExMan.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExMan.AWS.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DependencyFactory.Resolve<UserDAC>().GetAuthorizedComponentsForUser("35c89528-bc06-4824-925b-e02134856353"));
        }

    }
}