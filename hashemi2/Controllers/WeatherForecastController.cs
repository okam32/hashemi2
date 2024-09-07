using hashemi2.Core.OtherObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hashemi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return Ok(Summaries);
        }
        [HttpGet]
        [Route("GetUserRoles")]
        [Authorize(Roles = StaticUserRole.USER)]
        public IActionResult GetUserRoles()
        {
            return Ok(Summaries);
        }
        [HttpGet]
        [Route("GetAdminRoles")]
        [Authorize(Roles = StaticUserRole.ADMIN)]
        public IActionResult GetAdminRoles()
        {
            return Ok(Summaries);
        }
        [HttpGet]
        [Route("GetOwnerRoles")]
        [Authorize(Roles = StaticUserRole.OWNER)]
        public IActionResult GetOwnerRoles()
        {
            return Ok(Summaries);
        }
    }
}
