using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private string GenerateJSONWebToken(int userId, string role)
        {
            var securityKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("ThisIsMySuperSecretKeyForJwtAuthentication12345"));

            var credentials =
                new SigningCredentials(
                    securityKey,
                    SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, role),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "myUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        public IActionResult Login()
        {
            string token = GenerateJSONWebToken(101, "Admin");

            return Ok(token);
        }
    }
}
