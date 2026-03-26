using MediatR;
using Microsoft.Extensions.Logging;
using RepairMind.Core.Models;
using RepairMind.Core.Repositories;

namespace RepairMind.Core.Features.Items.Commands;

public record CreateItemCommand(string Name, string Category) : IRequest<Item>;

public class CreateItemHandler : IRequestHandler<CreateItemCommand, Item>
{
    private readonly IItemRepository _repository;
    private readonly ILogger<CreateItemHandler> _logger;

    public CreateItemHandler(IItemRepository repository, ILogger<CreateItemHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public Task<Item> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating item: {Name} in category {Category}",
            request.Name, request.Category);

        var item = new Item { Name = request.Name, Category = request.Category };
        var created = _repository.Add(item);

        _logger.LogInformation("Item created with ID: {Id}", created.Id);

        return Task.FromResult(created);
    }
}