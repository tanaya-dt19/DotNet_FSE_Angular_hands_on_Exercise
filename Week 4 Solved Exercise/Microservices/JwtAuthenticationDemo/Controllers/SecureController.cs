using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        /// <summary>
        /// Exercise 2: Protected endpoint - requires valid JWT token
        /// </summary>
        [HttpGet("data")]
        [Authorize]
        public IActionResult GetSecureData()
        {
            var username = User.Identity?.Name;
            var role = User.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value ?? "Not Set";

            return Ok(new
            {
                message = "This is protected data",
                username = username,
                role = role,
                timestamp = DateTime.Now
            });
        }

        /// <summary>
        /// Exercise 2: Get user profile with all claims
        /// </summary>
        [HttpGet("profile")]
        [Authorize]
        public IActionResult GetUserProfile()
        {
            var username = User.Identity?.Name;
            var claims = User.Claims.Select(c => new { Type = c.Type, Value = c.Value }).ToList();

            return Ok(new
            {
                username = username,
                claimsCount = claims.Count,
                claims = claims,
                message = "User profile retrieved successfully"
            });
        }

        /// <summary>
        /// Exercise 2: Get user roles
        /// </summary>
        [HttpGet("roles")]
        [Authorize]
        public IActionResult GetUserRoles()
        {
            var roles = User.FindAll(System.Security.Claims.ClaimTypes.Role).Select(c => c.Value).ToList();
            var username = User.Identity?.Name;

            return Ok(new
            {
                username = username,
                roles = roles,
                isAdmin = roles.Contains("Admin")
            });
        }
    }
}