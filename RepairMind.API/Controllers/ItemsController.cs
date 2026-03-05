using Microsoft.AspNetCore.Mvc;

namespace RepairMind.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("RepairMind is alive 🌱");
    }
}