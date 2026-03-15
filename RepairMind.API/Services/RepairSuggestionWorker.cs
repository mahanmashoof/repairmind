using Microsoft.EntityFrameworkCore;
using RepairMind.API.Data;

namespace RepairMind.API.Services;

public class RepairSuggestionWorker : BackgroundService
{
    private readonly RepairSuggestionQueue _queue;
    private readonly IServiceScopeFactory _scopeFactory;

    public RepairSuggestionWorker(
        RepairSuggestionQueue queue,
        IServiceScopeFactory scopeFactory)
    {
        _queue = queue;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_queue.TryDequeue(out var job))
            {
                using var scope = _scopeFactory.CreateScope();

                var suggestionService = scope.ServiceProvider
                    .GetRequiredService<IRepairSuggestionService>();
                var db = scope.ServiceProvider
                    .GetRequiredService<AppDbContext>();

                var suggestion = await suggestionService
                    .GetSuggestionAsync(job!.ItemName, job.ProblemDescription);

                var request = await db.RepairRequests
                    .FirstOrDefaultAsync(r => r.Id == job.RepairRequestId, stoppingToken);

                if (request is not null)
                {
                    request.AiSuggestion = suggestion;
                    await db.SaveChangesAsync(stoppingToken);
                }
            }
            else
            {
                await Task.Delay(1000, stoppingToken); // wait 1s before checking again
            }
        }
    }
}