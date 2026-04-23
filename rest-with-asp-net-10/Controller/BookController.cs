using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10.Domain;
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
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting all books.");

            List<Book> books = _service.GetAll();

            if (!books.Any())
            {
                _logger.LogInformation("No books found.");
                return NoContent();
            }

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Getting book with ID {id}.", id);

            Book? book = _service.GetById(id);

            if (book is null)
            {
                _logger.LogWarning("Book with ID {id} not found.", id);
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            _logger.LogInformation("Creating new book with title {title}", book.Title);

            if (book is null)
            {
                _logger.LogError("Failed to create book.");
                return BadRequest();
            }

            var bookCreated = _service.Create(book);
            return Ok(bookCreated);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            _logger.LogInformation("Updating book with ID {id}.", book.Id);

            if (book is null)
            {
                _logger.LogError("Failed to update book.");
                return BadRequest();
            }

            var bookUpdated = _service.Update(book);

            if (bookUpdated is null)
            {
                _logger.LogError("Failed to found book.");
                return NotFound();
            }

            return Ok(bookUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting book with ID {id}", id);

            Book? book = _service.GetById(id);

            if (book is null)
            {
                _logger.LogError("Failed to delete book with ID {id}", id);
                return NotFound();
            }

            _service.Delete(id);
            return NoContent();
        }
    }
}
