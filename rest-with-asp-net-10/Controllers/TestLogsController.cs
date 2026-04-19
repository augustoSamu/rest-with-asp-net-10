using Microsoft.AspNetCore.Mvc;

namespace rest_with_asp_net_10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLogsController : ControllerBase
    {
        private readonly ILogger _logger;

        public TestLogsController(ILogger<TestLogsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult LogTest()
        {
            _logger.LogTrace("This is an trace log.");
            _logger.LogDebug("This is an debug log.");
            _logger.LogInformation("This is an information log.");
            _logger.LogWarning("This is a warning log.");
            _logger.LogError("This is an error log.");
            return Ok("Logs have been written. Check your console or debug output.");
        }
    }
}
