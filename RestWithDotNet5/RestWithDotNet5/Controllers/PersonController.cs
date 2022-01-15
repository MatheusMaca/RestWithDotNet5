using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithDotNet5.Busines.Implementations;
using System;
using RestWithDotNet5.Data.VO;
using RestWithDotNet5.Hypermedia.Filters;

namespace RestWithDotNet5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonBusines _personBusines;

        public PersonController(ILogger<PersonController> logger, IPersonBusines personBusines)
        {
            _personBusines = personBusines;
            _logger = logger;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            _logger.LogInformation($"Requisição registrada em {DateTimeOffset.UtcNow}");
            return Ok(_personBusines.FindAll());
        }
        
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personBusines.FindById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }
        
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();

            return Ok(_personBusines.Create(person));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
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
