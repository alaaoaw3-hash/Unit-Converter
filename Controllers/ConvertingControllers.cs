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
        return Ok(Tools.Convert(receivedNumberObj));
    }
}