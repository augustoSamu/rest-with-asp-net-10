using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10.DTOs.V1;
using rest_with_asp_net_10.Service;

namespace rest_with_asp_net_10.Controller.V1
{
    [ApiController]
    [Route("[controller]/v1")]
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
        [ProducesResponseType(200, Type = typeof(List<BookDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting all books.");

            IEnumerable<BookDTO> booksDTO = _service.GetAll();

            if (!booksDTO.Any())
            {
                _logger.LogInformation("No books found.");
                return NoContent();
            }

            return Ok(booksDTO);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Getting book with ID {id}.", id);

            BookDTO? bookDTO = _service.GetById(id);

            if (bookDTO is null)
            {
                _logger.LogWarning("Book with ID {id} not found.", id);
                return NotFound();
            }

            return Ok(bookDTO);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create([FromBody] BookDTO bookDTO)
        {
            _logger.LogInformation("Creating new book with title {title}", bookDTO.Title);

            if (bookDTO is null)
            {
                _logger.LogError("Failed to create book.");
                return BadRequest();
            }

            var bookDTOCreated = _service.Create(bookDTO);
            return Ok(bookDTOCreated);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult Update([FromBody] BookDTO bookDTO)
        {
            _logger.LogInformation("Updating book with ID {id}.", bookDTO.Id);

            if (bookDTO is null)
            {
                _logger.LogError("Failed to update book.");
                return BadRequest();
            }

            var bookDTOUpdated = _service.Update(bookDTO);

            if (bookDTOUpdated is null)
            {
                _logger.LogError("Failed to found book.");
                return NotFound();
            }

            return Ok(bookDTOUpdated);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(BookDTO))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting book with ID {id}", id);

            BookDTO? book = _service.GetById(id);

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
