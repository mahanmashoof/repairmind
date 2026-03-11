using RepairMind.API.Data;
using RepairMind.API.Models;

namespace RepairMind.API.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _db;

    public ItemRepository(AppDbContext db)
    {
        _db = db;
    }

    public List<Item> GetAll() => _db.Items.ToList();

    public Item? GetById(Guid id) => _db.Items.FirstOrDefault(i => i.Id == id);

    public Item Add(Item item)
    {
        _db.Items.Add(item);
        _db.SaveChanges();
        return item;
    }
}