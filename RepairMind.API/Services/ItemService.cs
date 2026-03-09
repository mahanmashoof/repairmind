namespace RepairMind.API.Services;

public class ItemService : IItemService
{
    private readonly List<Item> _items = new();

    public List<Item> GetAll() => _items;

    public Item? GetById(Guid id) => _items.FirstOrDefault(i => i.Id == id);

    public Item Create(Item item)
    {
        _items.Add(item);
        return item;
    }
}