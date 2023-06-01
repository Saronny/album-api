using Microsoft.AspNetCore.Mvc;

namespace Album.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> GetHealth()
    {
        return Ok("Healthy");
    }
}