using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// Exercise 3: Admin only endpoint
        /// </summary>
        [HttpGet("dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminDashboard()
        {
            var username = User.Identity?.Name;

            return Ok(new
            {
                message = "Welcome to the admin dashboard",
                username = username,
                data = new
                {
                    activeUsers = 152,
                    apiCalls = 5432,
                    systemHealth = "Good",
                    lastUpdated = DateTime.Now
                }
            });
        }

        /// <summary>
        /// Exercise 3: Get all users - Admin only
        /// </summary>
        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            var users = new[]
            {
                new { id = 1, name = "Admin User", username = "admin", role = "Admin", status = "Active" },
                new { id = 2, name = "Regular User", username = "user", role = "User", status = "Active" }
            };

            return Ok(new
            {
                totalUsers = users.Length,
                users = users,
                timestamp = DateTime.Now
            });
        }

        /// <summary>
        /// Exercise 3: Get system statistics - Admin only
        /// </summary>
        [HttpGet("statistics")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetSystemStatistics()
        {
            return Ok(new
            {
                statistics = new
                {
                    totalLogins = 1250,
                    failedAttempts = 45,
                    averageResponseTime = "120ms",
                    uptime = "99.9%",
                    serverLoad = "45%"
                },
                timestamp = DateTime.Now
            });
        }

        /// <summary>
        /// Exercise 3: Manage system settings - Admin only
        /// </summary>
        [HttpPost("settings")]
        [Authorize(Roles = "Admin")]
        public IActionResult ManageSystemSettings([FromBody] object settings)
        {
            var username = User.Identity?.Name;

            return Ok(new
            {
                message = "System settings updated successfully",
                updatedBy = username,
                settings = settings,
                timestamp = DateTime.Now
            });
        }

        /// <summary>
        /// Exercise 3: Delete user - Admin only
        /// </summary>
        [HttpDelete("users/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(int id)
        {
            var username = User.Identity?.Name;

            return Ok(new
            {
                message = $"User {id} deleted successfully",
                deletedBy = username,
                timestamp = DateTime.Now
            });
        }
    }
}