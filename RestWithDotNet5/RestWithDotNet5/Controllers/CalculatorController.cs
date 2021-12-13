using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithDotNet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Inputs");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtraction = Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);
                return Ok(subtraction.ToString());
            }
            return BadRequest("Invalid Inputs");
        }

        [HttpGet("multiply/{firstNumber}/{secondNumber}")]
        public IActionResult Multiply(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiply = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);
                return Ok(multiply.ToString());
            }
            return BadRequest("Invalid Inputs");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            bool isNumeric = IsNumeric(firstNumber) && IsNumeric(secondNumber);
            
            bool isDifferentZero = false;
            if (isNumeric)
            {
                isDifferentZero = Convert.ToDecimal(firstNumber) != 0 && Convert.ToDecimal(secondNumber) != 0;
            }

            if (isNumeric && isDifferentZero)
            {
                var division = Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);
                return Ok(division.ToString());
            }

            return BadRequest("Invalid Inputs");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = (Convert.ToDecimal(firstNumber) +  Convert.ToDecimal(secondNumber)) / 2;
                return Ok(mean.ToString());
            }
            return BadRequest("Invalid Inputs");
        }

        [HttpGet("square-root/{Number}")]
        public IActionResult SquareRoot(string Number)
        {
            if (IsNumeric(Number))
            {
                var squareRoot = Math.Sqrt((double)Convert.ToDecimal(Number));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid Inputs");
        }

        private bool IsNumeric(string value)
        {
            double number;
            bool isNumber = double.TryParse(
                value,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }
    }
}
