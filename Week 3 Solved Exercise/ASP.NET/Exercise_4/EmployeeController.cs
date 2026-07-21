using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Hardcoded Employee List
        static List<Employee> employees = new List<Employee>()
        {
            new Employee
            {
                Id = 1,
                Name = "Rahul",
                Department = "IT",
                Salary = 50000
            },
            new Employee
            {
                Id = 2,
                Name = "Amit",
                Department = "HR",
                Salary = 45000
            },
            new Employee
            {
                Id = 3,
                Name = "Priya",
                Department = "Finance",
                Salary = 60000
            }
        };

        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
            {
                return BadRequest("Invalid employee id");
            }

            emp.Name = employee.Name;
            emp.Department = employee.Department;
            emp.Salary = employee.Salary;

            return Ok(emp);
        }
    }
}
