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

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_service.FindAll());
        }


        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var person = _service.FindById(id);

            if (person is null)
                return NotFound("Person not found.");

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person is null)
                return BadRequest("Person must be real.");

            var personCreated = _service.Create(person);

            return Ok(personCreated);
        }

        [HttpPost]
        public IActionResult Update([FromBody] Person person)
        {
            if (person is null)
                return BadRequest("Person must be real.");

            var personUpdate = _service.Update(person);

            return Ok(personUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
