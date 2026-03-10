using Microsoft.EntityFrameworkCore;
using RepairMind.API.Data;
using RepairMind.API.Models;

namespace RepairMind.API.Services;

public class ItemService : IItemService
{
    private readonly AppDbContext _db;

    public ItemService(AppDbContext db)
    {
        _db = db;
    }

    public List<Item> GetAll() => _db.Items.ToList();

    public Item? GetById(Guid id) => _db.Items.FirstOrDefault(i => i.Id == id);
    public Item Create(Item item)
    {
        _db.Items.Add(item);
        _db.SaveChanges();
        return item;
    }
}