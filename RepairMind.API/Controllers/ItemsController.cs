using Microsoft.AspNetCore.Mvc;
using RepairMind.API.Models;
namespace RepairMind.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private static readonly List<Item> _items = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(_items);

    [HttpPost]
    public IActionResult Create(Item item)
    {
        _items.Add(item);
        return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
    }
}