using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Controllers
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
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertStringToDecimal(firstNumber) + ConvertStringToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string str)
        {
            return double.TryParse(str, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out _);
        }

        private decimal ConvertStringToDecimal(string str)
        {
            _ = decimal.TryParse(str, out decimal decimalValue);

            return decimalValue;
        }
    }
}
