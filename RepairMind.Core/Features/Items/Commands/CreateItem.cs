using MediatR;
using RepairMind.Core.Models;
using RepairMind.Core.Repositories;

namespace RepairMind.Core.Features.Items.Commands;

public record CreateItemCommand(string Name, string Category) : IRequest<Item>;

public class CreateItemHandler : IRequestHandler<CreateItemCommand, Item>
{
    private readonly IItemRepository _repository;

    public CreateItemHandler(IItemRepository repository)
    {
        _repository = repository;
    }

    public Task<Item> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var item = new Item { Name = request.Name, Category = request.Category };
        return Task.FromResult(_repository.Add(item));
    }
}