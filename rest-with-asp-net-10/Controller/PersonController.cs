using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10.Domain;
using rest_with_asp_net_10.Service;

namespace rest_with_asp_net_10.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonService service, ILogger<PersonController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting all persons.");

            List<Person> persons = _service.GetAll();

            if (!persons.Any())
            {
                _logger.LogInformation("No persons found.");
                return NoContent();
            }

            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Getting person with ID {id}.", id);

            Person? person = _service.GetById(id);

            if (person is null)
            {
                _logger.LogWarning("Person with ID {id} not found.", id);
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            _logger.LogInformation("Creating new person with name {firstName}.", person.FirstName);

            if (person is null)
            {
                _logger.LogError("Failed to create person.");
                return BadRequest();
            }

            Person personCreated = _service.Create(person);
            return Ok(personCreated);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            _logger.LogInformation("Updating person with ID {id}", person.Id);

            if (person is null)
            {
                _logger.LogError("Failed to update person.");
                return BadRequest();
            }

            Person? personUpdate = _service.Update(person);

            if (personUpdate is null)
            {
                _logger.LogError("Failed to found person.");
                return NotFound();
            }

            return Ok(personUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting person with ID {id}", id);

            Person? person = _service.GetById(id);

            if (person is null)
            {
                _logger.LogError("Failed to delete person with ID {id}", id);
                return NotFound();
            }

            _service.Delete(id);
            return NoContent();
        }
    }
}
