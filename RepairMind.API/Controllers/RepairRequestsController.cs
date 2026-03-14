using Microsoft.AspNetCore.Mvc;
using RepairMind.API.Models;
using RepairMind.API.Services;

namespace RepairMind.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RepairRequestsController : ControllerBase
{
    private static readonly List<RepairRequest> _requests = new();
    private readonly IRepairSuggestionService _suggestionService;
    public RepairRequestsController(IRepairSuggestionService suggestionService)
    {
        _suggestionService = suggestionService;
    }

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

    [HttpPost("{id}/suggest")]
    public async Task<IActionResult> GetSuggestion(Guid id)
    {
        var request = _requests.FirstOrDefault(r => r.Id == id);
        if (request is null) return NotFound();

        var suggestion = await _suggestionService.GetSuggestionAsync(
            "unknown item",
            request.ProblemDescription
        );

        return Ok(new { suggestion });
    }
}