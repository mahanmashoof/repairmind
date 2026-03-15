using RepairMind.API.Data;
using RepairMind.API.Models;

namespace RepairMind.API.Repositories;

public class RepairRequestRepository : IRepairRequestRepository
{
    private readonly AppDbContext _db;

    public RepairRequestRepository(AppDbContext db)
    {
        _db = db;
    }

    public List<RepairRequest> GetAll() => _db.RepairRequests.ToList();

    public RepairRequest? GetById(Guid id) =>
        _db.RepairRequests.FirstOrDefault(r => r.Id == id);

    public RepairRequest Add(RepairRequest request)
    {
        _db.RepairRequests.Add(request);
        _db.SaveChanges();
        return request;
    }

    public void Update(RepairRequest request)
    {
        _db.RepairRequests.Update(request);
        _db.SaveChanges();
    }
}