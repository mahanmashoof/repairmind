using RepairMind.Core.Models;

namespace RepairMind.Core.Services;

public interface IItemService
{
    List<Item> GetAll();
    Item? GetById(Guid id);
    Item Create(Item item);
}