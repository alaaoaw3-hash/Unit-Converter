using Microsoft.AspNetCore.Mvc;

namespace Unit_Converter.Controllers;


[ApiController]
[Route("api/convertNumber")]
public class ConvertingController : ControllerBase
{
    [HttpPost]
    public IActionResult Convert([FromBody] NumberToConvert receivedNumberObj)
    {
        Console.WriteLine($"Request received!\nNumber: {receivedNumberObj.Number}, From: {receivedNumberObj.CurrentUnit}");
        if (string.IsNullOrEmpty(receivedNumberObj.UnitType) || string.IsNullOrEmpty(receivedNumberObj.CurrentUnit) || string.IsNullOrEmpty(receivedNumberObj.TargetUnit))
        {
            return BadRequest("There is a value that is empty or null");
        }
        else if (receivedNumberObj.Number < 0 && !string.Equals("temperature", receivedNumberObj.UnitType.ToLower()))
        {
            return BadRequest("Number is negative and unit type is not temperature");
        }


        ConversionVerdict conversionOutcome = Tools.Convert(receivedNumberObj);

        // check if the process of conversion failed
        if (!conversionOutcome.IsSuccessfullConversion)
        {
            return BadRequest("Unsuccessfull conversion. Try again.");
        }


        return Ok(conversionOutcome.Result);
    }
}