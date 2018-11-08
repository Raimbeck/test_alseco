using System.Threading.Tasks;
using API.Interfaces;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository repository;
        public EmployeesController(IEmployeesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(Filter filter)
        {
            return Ok(await repository.GetEmployees(filter));
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            return Ok(await repository.GetEmployee(id));
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetEmployeesCount() {
            return Ok(await repository.GetEmployeesCount());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody]EmployeeDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var response = await repository.CreateEmployee(dto);
            if(response == null)
                return BadRequest("Could not create an employee.");
            
            return CreatedAtRoute("GetEmployee", new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody]EmployeeDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await repository.UpdateEmployee(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return Ok(await repository.DeleteEmployee(id));
        }
    }
}