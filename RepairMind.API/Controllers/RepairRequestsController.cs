using Microsoft.AspNetCore.Mvc;
using RepairMind.API.Models;
using RepairMind.API.Repositories;
using RepairMind.API.Services;

namespace RepairMind.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RepairRequestsController : ControllerBase
{
    private readonly IRepairRequestRepository _repository;
    private readonly IRepairSuggestionService _suggestionService;
    private readonly RepairSuggestionQueue _queue;

    public RepairRequestsController(
        IRepairRequestRepository repository,
        IRepairSuggestionService suggestionService,
        RepairSuggestionQueue queue)
    {
        _repository = repository;
        _suggestionService = suggestionService;
        _queue = queue;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_repository.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var request = _repository.GetById(id);
        return request is null ? NotFound() : Ok(request);
    }

    [HttpPost]
    public IActionResult Create(RepairRequest request)
    {
        var created = _repository.Add(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPatch("{id}/status")]
    public IActionResult UpdateStatus(Guid id, [FromBody] RepairStatus status)
    {
        var request = _repository.GetById(id);
        if (request is null) return NotFound();
        request.Status = status;
        _repository.Update(request);
        return Ok(request);
    }

    [HttpPost("{id}/suggest")]
    public IActionResult RequestSuggestion(Guid id)
    {
        var request = _repository.GetById(id);
        if (request is null) return NotFound();

        _queue.Enqueue(new SuggestionJob
        {
            RepairRequestId = request.Id,
            ItemName = "unknown item",
            ProblemDescription = request.ProblemDescription
        });

        return Accepted(new { message = "Suggestion is being generated." });
    }
}