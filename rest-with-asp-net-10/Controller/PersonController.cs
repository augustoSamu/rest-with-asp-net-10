using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10.DTOs;
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

            IEnumerable<PersonDTO> personsDTO = _service.GetAll();

            if (!personsDTO.Any())
            {
                _logger.LogInformation("No persons found.");
                return NoContent();
            }

            return Ok(personsDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Getting person with ID {id}.", id);

            PersonDTO? personDTO = _service.GetById(id);

            if (personDTO is null)
            {
                _logger.LogWarning("Person with ID {id} not found.", id);
                return NotFound();
            }

            return Ok(personDTO);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonDTO personDTO)
        {
            _logger.LogInformation("Creating new person with name {firstName}.", personDTO.FirstName);

            if (personDTO is null)
            {
                _logger.LogError("Failed to create person.");
                return BadRequest();
            }

            PersonDTO personDTOCreated = _service.Create(personDTO);
            return Ok(personDTOCreated);
        }

        [HttpPut]
        public IActionResult Update([FromBody] PersonDTO personDTO)
        {
            _logger.LogInformation("Updating person with ID {id}", personDTO.Id);

            if (personDTO is null)
            {
                _logger.LogError("Failed to update person.");
                return BadRequest();
            }

            PersonDTO? personUpdate = _service.Update(personDTO);

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

            PersonDTO? personDTO = _service.GetById(id);

            if (personDTO is null)
            {
                _logger.LogError("Failed to delete person with ID {id}", id);
                return NotFound();
            }

            _service.Delete(id);
            return NoContent();
        }
    }
}
