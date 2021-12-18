using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithDotNet5.Model;
using RestWithDotNet5.Busines.Implementations;
using System;

namespace RestWithDotNet5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IPersonBusines _personBusines;

        public PersonController(ILogger<CalculatorController> logger, IPersonBusines personBusines)
        {
            _personBusines = personBusines;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation($"Requisição registrada em {DateTimeOffset.UtcNow}");
            return Ok(_personBusines.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusines.FindById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return Ok(_personBusines.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {

            if (person == null)
                return BadRequest();

            return Ok(_personBusines.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusines.Delete(id);
            return NoContent();
        }
    }
}
