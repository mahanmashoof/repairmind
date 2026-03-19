using RepairMind.Core.Models;

namespace RepairMind.Core.Repositories;

public interface IItemRepository
{
    List<Item> GetAll();
    Item? GetById(Guid id);
    Item Add(Item item);
}