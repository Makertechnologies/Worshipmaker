using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Worshipmaker.Api.Authentication
{
    public class TokenManager : ITokenManager
    {
        private readonly IConfiguration _Configuration;

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public TokenManager(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        /// <summary>
        /// Creates a token for the specified user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string CreateToken(string username)
        {
            var key = _Configuration.GetValue<string>("TokenConfig:Key") ?? "";
            var bytes = Encoding.UTF8.GetBytes(key);
            var handler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, username) }),
                Expires = DateTime.UtcNow.AddMinutes(30), // TODO2024 figure out token expiration
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
    }

    public interface ITokenManager
    {
        public string CreateToken(string username);
    }
}