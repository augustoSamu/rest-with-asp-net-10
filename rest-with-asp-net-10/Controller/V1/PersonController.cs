using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10.DTOs.V1;
using rest_with_asp_net_10.Service;

namespace rest_with_asp_net_10.Controller.V1
{
    [ApiController]
    [Route("[controller]/v1")]
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
        [ProducesResponseType(200, Type = typeof(List<PersonDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
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
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
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
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create([FromBody] PersonDTO personDTO)
        {
            _logger.LogInformation("Creating new person with name {firstName}.", personDTO.FirstName);

            if (personDTO is null)
            {
                _logger.LogError("Failed to create person.");
                return BadRequest();
            }

            PersonDTO personDTOCreated = _service.Create(personDTO);

            Response.Headers.Add("X-API-Deprecated", "true");
            Response.Headers.Add("X-API-Deprecation-Date", "2026-04-26");
            return Ok(personDTOCreated);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
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
        [ProducesResponseType(204, Type = typeof(PersonDTO))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
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
