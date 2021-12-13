using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithDotNet5.Model;
using RestWithDotNet5.Services.Implementations;

namespace RestWithDotNet5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<CalculatorController> logger, IPersonService personService)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {

            if (person == null)
                return BadRequest();

            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
