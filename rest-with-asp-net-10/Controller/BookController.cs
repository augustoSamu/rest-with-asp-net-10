using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10.Model;
using rest_with_asp_net_10.Service;

namespace rest_with_asp_net_10.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService service, ILogger<BookController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            _logger.LogInformation("Finding all books.");
            return Ok(_service.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            _logger.LogInformation("Finding book with ID {id}", id);
            var person = _service.FindById(id);

            if (person is null)
            {
                _logger.LogWarning("Book with ID {id} not found", id);
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            _logger.LogInformation("Creating new book with title {title}", book.Title);
            if (book is null)
            {
                _logger.LogError("Failed to create book");
                return BadRequest();
            }

            var bookCreated = _service.Create(book);
            return Ok(bookCreated);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            _logger.LogInformation("Updating book with ID {id}", book.Id);

            var bookUpdated = _service.Update(book);

            if (book is null)
            {
                _logger.LogError("Failed to update book with ID {id}", book.Id);
                return BadRequest();
            }

            _logger.LogDebug("Book updated successfully with ID {id}", book.Id);
            return Ok(bookUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting book with ID {id}", id);
            _service.Delete(id);

            _logger.LogDebug("Book deleted successfully with ID {id}", id);
            return NoContent();
        }
    }
}
