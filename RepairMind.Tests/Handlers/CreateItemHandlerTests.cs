using Moq;
using RepairMind.Core.Features.Items.Commands;
using RepairMind.Core.Models;
using RepairMind.Core.Repositories;

namespace RepairMind.Tests.Handlers;

public class CreateItemHandlerTests
{
    [Fact]
    public async Task Handle_CreatesAndReturnsItem()
    {
        // Arrange
        var mockRepo = new Mock<IItemRepository>();
        mockRepo.Setup(r => r.Add(It.IsAny<Item>()))
                .Returns((Item item) => item);

        var handler = new CreateItemHandler(mockRepo.Object);
        var command = new CreateItemCommand("Blender", "Kitchen");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal("Blender", result.Name);
        Assert.Equal("Kitchen", result.Category);
        mockRepo.Verify(r => r.Add(It.IsAny<Item>()), Times.Once);
    }
}