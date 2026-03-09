namespace RepairMind.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_itemService.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var item = _itemService.GetById(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public IActionResult Create(Item item)
    {
        var created = _itemService.Create(item);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}