using Microsoft.AspNetCore.Mvc;

namespace rest_with_asp_net_10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input!");
            }

            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum);
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
