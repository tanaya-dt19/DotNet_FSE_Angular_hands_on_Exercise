using EmployeeWebApi.Filters;
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> employees;

        public EmployeeController()
        {
            employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Shamal",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department
                    {
                        Id = 1,
                        Name = "IT"
                    },
                    Skills = new List<Skill>()
                    {
                        new Skill
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new Skill
                        {
                            Id = 2,
                            Name = "SQL"
                        }
                    },
                    DateOfBirth =
                        new DateTime(2002,5,10)
                }
            };
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> GetStandard()
        {
            throw new Exception("Sample Exception");

            // return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee(
            [FromBody] Employee employee)
        {
            employees.Add(employee);

            return Ok(employee);
        }

        [HttpPut]
        public IActionResult UpdateEmployee(
            [FromBody] Employee employee)
        {
            return Ok(employee);
        }
    }
}