using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairMind.Core.Features.Items.Commands;
using RepairMind.Core.Features.Items.Queries;

namespace RepairMind.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllItemsQuery()));

    [HttpPost]
    public async Task<IActionResult> Create(CreateItemCommand command)
    {
        var item = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
    }
}