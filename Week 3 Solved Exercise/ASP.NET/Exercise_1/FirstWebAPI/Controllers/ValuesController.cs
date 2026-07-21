using Microsoft.AspNetCore.Mvc;
namespace FirstWebApi.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[]
            {
                "Apple",
                "Banana",
                "Orange"
            });
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"ID = {id}");
        }
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"Added : {value}");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok($"Updated ID = {id} with Value = {value}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleted ID = {id}");
        }
    }
}