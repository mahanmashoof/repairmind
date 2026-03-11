using RepairMind.API.Models;

namespace RepairMind.API.Repositories;

public interface IItemRepository
{
    List<Item> GetAll();
    Item? GetById(Guid id);
    Item Add(Item item);
}