using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10.Services;
using rest_with_asp_net_10.Utils;

namespace rest_with_asp_net_10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private readonly MathService _service;

        public MathController(MathService service)
        {
            _service = service;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (!NumberHelper.IsNumeric(firstNumber) || !NumberHelper.IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input!");
            }

            var result = _service.Sum(
                NumberHelper.ConvertToDouble(firstNumber),
                NumberHelper.ConvertToDouble(secondNumber)
                );
            return Ok(result);
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (!NumberHelper.IsNumeric(firstNumber) || !NumberHelper.IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input!");
            }

            var result = _service.Subtraction(
                NumberHelper.ConvertToDouble(firstNumber),
                NumberHelper.ConvertToDouble(secondNumber)
                );
            return Ok(result);
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (!NumberHelper.IsNumeric(firstNumber) || !NumberHelper.IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input!");
            }

            var result = _service.Multiplication(
                NumberHelper.ConvertToDouble(firstNumber),
                NumberHelper.ConvertToDouble(secondNumber)
                );
            return Ok(result);
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (!NumberHelper.IsNumeric(firstNumber) || !NumberHelper.IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input!");
            }

            var result = _service.Division(
                NumberHelper.ConvertToDouble(firstNumber),
                NumberHelper.ConvertToDouble(secondNumber)
                );
            return Ok(result);
        }

        [HttpGet("avg/{firstNumber}/{secondNumber}")]
        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {
            if (!NumberHelper.IsNumeric(firstNumber) || !NumberHelper.IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input!");
            }

            var result = _service.Average(
                NumberHelper.ConvertToDouble(firstNumber),
                NumberHelper.ConvertToDouble(secondNumber)
                );
            return Ok(result);
        }

        [HttpGet("sqrt/{number}")]
        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (!NumberHelper.IsNumeric(number))
            {
                return BadRequest("Invalid Input!");
            }

            var result = _service.SquareRoot(NumberHelper.ConvertToDouble(number));
            return Ok(result);
        }
    }
}
