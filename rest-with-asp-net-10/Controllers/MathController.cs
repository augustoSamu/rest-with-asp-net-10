using Microsoft.AspNetCore.Mvc;

namespace rest_with_asp_net_10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input!");
            }

            var result = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(result);
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input!");
            }

            var result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(result);
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input!");
            }

            var result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(result);
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input!");
            }

            if (firstNumber == "0" || firstNumber == "0")
            {
                return BadRequest("Cannot division by zero!");
            }

            var result = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(result);
        }

        [HttpGet("avg/{firstNumber}/{secondNumber}")]
        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input!");
            }

            var result = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
            return Ok(result);
        }

        [HttpGet("sqrt/{number}")]
        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (!IsNumeric(number))
            {
                return BadRequest("Invalid Input!");
            }

            var result = Math.Sqrt((double)ConvertToDecimal(number));
            return Ok(result);
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            if (decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimal value))
            {
                return value;
            }

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            return decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimal value);
        }
    }
}
