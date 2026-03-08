namespace RepairMind.API.Models;

public class RepairRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ItemId { get; set; }
    public string ProblemDescription { get; set; } = string.Empty;
    public RepairStatus Status { get; set; } = RepairStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public enum RepairStatus
{
    Pending,
    InProgress,
    Resolved
}