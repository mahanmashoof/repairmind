using RepairMind.API.Models;

namespace RepairMind.API.Services;

public interface IItemService
{
    List<Item> GetAll();
    Item? GetById(Guid id);
    Item Create(Item item);
}