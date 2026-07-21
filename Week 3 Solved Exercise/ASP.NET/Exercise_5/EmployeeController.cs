using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(new string[]
            {
                "Rahul",
                "Amit",
                "Shamal"
            });
        }
    }
}
