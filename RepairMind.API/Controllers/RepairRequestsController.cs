using Microsoft.AspNetCore.Mvc;
using RepairMind.API.Models;

namespace RepairMind.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RepairRequestsController : ControllerBase
{
    private static readonly List<RepairRequest> _requests = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(_requests);

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var request = _requests.FirstOrDefault(r => r.Id == id);
        return request is null ? NotFound() : Ok(request);
    }

    [HttpPost]
    public IActionResult Create(RepairRequest request)
    {
        _requests.Add(request);
        return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
    }

    [HttpPatch("{id}/status")]
    public IActionResult UpdateStatus(Guid id, [FromBody] RepairStatus status)
    {
        var request = _requests.FirstOrDefault(r => r.Id == id);
        if (request is null) return NotFound();
        request.Status = status;
        return Ok(request);
    }
}