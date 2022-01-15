using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithDotNet5.Busines.Implementations;
using RestWithDotNet5.Data.VO;
using RestWithDotNet5.Hypermedia.Filters;

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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            var books = _bookBusines.FindAll();

            if (books == null)
                return NotFound();

            return Ok(books);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var book = _bookBusines.FindById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();

            return Ok(_bookBusines.Create(book));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
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
