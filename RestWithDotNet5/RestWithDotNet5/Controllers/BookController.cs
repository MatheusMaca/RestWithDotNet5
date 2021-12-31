using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithDotNet5.Busines.Implementations;
using RestWithDotNet5.Model;

namespace RestWithDotNet5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookBusines _bookBusines;

        public BookController(ILogger<BookController> logger, IBookBusines bookBusines)
        {
            _logger = logger;
            _bookBusines = bookBusines;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var books = _bookBusines.FindAll();

            if (books == null)
                return NotFound();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookBusines.FindById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            return Ok(_bookBusines.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            return Ok(_bookBusines.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var book = _bookBusines.FindById(id);
            if (book == null)
                return NotFound();

            _bookBusines.Delete(id);
            return Ok(book);
        }
    }
}
