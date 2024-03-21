using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Worshipmaker.Api.Authentication;

namespace Worshipmaker.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenManager _TokenManager;

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="tokenManager"></param>
        public AuthenticationController(ITokenManager tokenManager)
        {
            _TokenManager = tokenManager;
        }

        /// <summary>
        /// POST: Signs in a user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult SignIn(string username, string password)
        {
            if (username == "test@test.com" && password == "password")
            {
                // TODO2024 make login work
                var token = _TokenManager.CreateToken(username);
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}