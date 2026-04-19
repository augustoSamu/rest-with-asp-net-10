using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10.Model;
using rest_with_asp_net_10.Services;

namespace rest_with_asp_net_10.Controllers
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
        public IActionResult FindAll()
        {
            _logger.LogInformation("Finding all persons.");
            return Ok(_service.FindAll());
        }


        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            _logger.LogInformation("Finding person with ID {id}", id);
            var person = _service.FindById(id);

            if (person is null)
            {
                _logger.LogWarning("Person with ID {id} not found", id);
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            _logger.LogInformation("Creating new person with name {firstName}", person.FirstName);
            if (person is null)
            {
                _logger.LogError("Failed to create person");
                return BadRequest("Person must be real.");
            }

            var personCreated = _service.Create(person);

            return Ok(personCreated);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            _logger.LogInformation("Updating person with ID {id}", person.Id);

            var personUpdate = _service.Update(person);

            if (personUpdate is null)
            {
                _logger.LogError("Failed to updade person with ID {id}", person.Id);
                return BadRequest("Person must be real.");
            }
            
            _logger.LogDebug("Person updated successfully with ID {id}", person.Id);
            return Ok(personUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting person with ID {id}", id);
            _service.Delete(id);

            _logger.LogDebug("Person deleted successfully with ID {id}", id);
            return NoContent();
        }
    }
}
