using RepairMind.Core.Models;
using RepairMind.Core.Repositories;
using RepairMind.Core.Services;

namespace RepairMind.API.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public List<Item> GetAll() => _itemRepository.GetAll();

    public Item? GetById(Guid id) => _itemRepository.GetById(id);

    public Item Create(Item item) => _itemRepository.Add(item);
}