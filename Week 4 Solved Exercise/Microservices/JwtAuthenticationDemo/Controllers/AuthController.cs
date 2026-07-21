using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthenticationDemo.Models;

namespace JwtAuthenticationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Exercise 1: Login endpoint - generates JWT token
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (string.IsNullOrEmpty(model?.Username) || string.IsNullOrEmpty(model?.Password))
            {
                return BadRequest(new { message = "Username and password are required" });
            }

            if (IsValidUser(model.Username, model.Password))
            {
                var token = GenerateJwtToken(model.Username);
                return Ok(new
                {
                    token = token,
                    message = "Login successful",
                    expiresIn = _configuration["Jwt:DurationInMinutes"] + " minutes"
                });
            }

            return Unauthorized(new { message = "Invalid username or password" });
        }

        /// <summary>
        /// Exercise 4: Refresh token endpoint
        /// </summary>
        [HttpPost("refresh-token")]
        [Authorize]
        public IActionResult RefreshToken()
        {
            try
            {
                var username = User.Identity?.Name;
                if (string.IsNullOrEmpty(username))
                {
                    return Unauthorized(new { message = "Unable to identify user from token" });
                }

                var newToken = GenerateJwtToken(username);
                return Ok(new
                {
                    token = newToken,
                    message = "Token refreshed successfully",
                    expiresIn = _configuration["Jwt:DurationInMinutes"] + " minutes"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

        private bool IsValidUser(string username, string password)
        {
            var validUsers = new Dictionary<string, string>
            {
                { "admin", "admin123" },
                { "user", "user123" }
            };

            if (validUsers.TryGetValue(username, out var storedPassword))
            {
                return storedPassword == password;
            }

            return false;
        }

        private string GenerateJwtToken(string username)
        {
            var jwtKey = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("JWT Key is not configured");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var role = username == "admin" ? "Admin" : "User";

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
                new Claim("LoginTime", DateTime.Now.ToString())
            };

            var durationStr = _configuration["Jwt:DurationInMinutes"];
            int duration = string.IsNullOrEmpty(durationStr) ? 60 : int.Parse(durationStr);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(duration),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}