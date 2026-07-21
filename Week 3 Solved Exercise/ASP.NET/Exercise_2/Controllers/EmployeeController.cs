using Microsoft.AspNetCore.Mvc;

using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
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
                Name = "Priya",
                Department = "HR",
                Salary = 45000
            },
            new Employee
            {
                Id = 3,
                Name = "Amit",
                Department = "Finance",
                Salary = 60000
            }
        };

        // GET: api/Employee
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        // GET: api/Employee/1
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        // POST: api/Employee
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddEmployee(Employee emp)
        {
            employees.Add(emp);
            return Ok("Employee Added Successfully");
        }

        // PUT: api/Employee/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateEmployee(int id, Employee emp)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            employee.Name = emp.Name;
            employee.Department = emp.Department;
            employee.Salary = emp.Salary;

            return Ok("Employee Updated Successfully");
        }

        // DELETE: api/Employee/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            employees.Remove(employee);

            return Ok("Employee Deleted Successfully");
        }
    }
}