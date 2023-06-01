using Microsoft.AspNetCore.Mvc;
using Album.Api.Services;
using Album.Api.Models;

namespace Album.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    private readonly GreetingService _greetingService;
    public HelloController(GreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    [HttpGet]
    public ActionResult<string> GetHello([FromQuery] string? name)
    {
        var greeting = _greetingService.GetGreeting(name);
        var model = new Model { Greeting = greeting };
        return Ok(model);
    }
}
