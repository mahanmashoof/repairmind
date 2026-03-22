using MediatR;
using RepairMind.Core.Models;
using RepairMind.Core.Repositories;

namespace RepairMind.Core.Features.Items.Queries;

public record GetAllItemsQuery() : IRequest<List<Item>>;

public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery, List<Item>>
{
    private readonly IItemRepository _repository;

    public GetAllItemsHandler(IItemRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Item>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        => Task.FromResult(_repository.GetAll());
}