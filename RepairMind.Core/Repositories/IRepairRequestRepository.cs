using RepairMind.Core.Models;

namespace RepairMind.Core.Repositories;

public interface IRepairRequestRepository
{
    List<RepairRequest> GetAll();
    RepairRequest? GetById(Guid id);
    RepairRequest Add(RepairRequest request);
    void Update(RepairRequest request);
}