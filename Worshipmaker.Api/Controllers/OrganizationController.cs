using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Worshipmaker.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrganizationController : ControllerBase
    {
        [HttpGet]
        public IActionResult List()
        {
            return Ok(new List<string> { "1", "2" });
        }

        [HttpPost]
        public IActionResult Read(string id)
        {
            return Ok(new List<string> { "3", "4" });
        }
    }
}