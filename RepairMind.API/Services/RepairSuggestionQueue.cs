using System.Collections.Concurrent;

namespace RepairMind.API.Services;

public class RepairSuggestionQueue
{
    private readonly ConcurrentQueue<SuggestionJob> _queue = new();

    public void Enqueue(SuggestionJob job) => _queue.Enqueue(job);

    public bool TryDequeue(out SuggestionJob? job) => _queue.TryDequeue(out job);
}

public class SuggestionJob
{
    public Guid RepairRequestId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string ProblemDescription { get; set; } = string.Empty;
}