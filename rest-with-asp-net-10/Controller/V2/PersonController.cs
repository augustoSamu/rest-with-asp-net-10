using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10.DTOs.V2;
using rest_with_asp_net_10.Service;

namespace rest_with_asp_net_10.Controller.V2
{
    [ApiController]
    [Route("[controller]/v2")]
    public class PersonController : ControllerBase
    {
        private readonly PersonServiceV2 _service;
        private readonly ILogger<PersonController> _logger;

        public PersonController(PersonServiceV2 service, ILogger<PersonController> logger)
        {
            _service = service;
            _logger = logger;
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
    }
}
