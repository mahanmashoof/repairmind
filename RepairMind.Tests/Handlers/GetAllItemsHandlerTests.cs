using Moq;
using RepairMind.Core.Features.Items.Queries;
using RepairMind.Core.Models;
using RepairMind.Core.Repositories;

namespace RepairMind.Tests.Handlers;

public class GetAllItemsHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsAllItems()
    {
        // Arrange — set up a fake filing room with two items
        var mockRepo = new Mock<IItemRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(new List<Item>
        {
            new Item { Name = "Toaster", Category = "Kitchen" },
            new Item { Name = "Lamp", Category = "Lighting" }
        });

        var handler = new GetAllItemsHandler(mockRepo.Object);

        // Act — ask the handler to do its job
        var result = await handler.Handle(new GetAllItemsQuery(), CancellationToken.None);

        // Assert — check the checklist
        Assert.Equal(2, result.Count);
        Assert.Contains(result, i => i.Name == "Toaster");
    }
}