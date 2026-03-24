using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RepairMind.API.Controllers;
using RepairMind.Core.Features.Items.Commands;
using RepairMind.Core.Features.Items.Queries;
using RepairMind.Core.Models;

namespace RepairMind.Tests.Controllers;

public class ItemsControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOkWithItems()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<GetAllItemsQuery>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new List<Item> { new Item { Name = "Toaster" } });

        var controller = new ItemsController(mockMediator.Object);

        // Act
        var result = await controller.GetAll();

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        var items = Assert.IsType<List<Item>>(ok.Value);
        Assert.Single(items);
    }

    [Fact]
    public async Task Create_ReturnsCreatedResult()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        var command = new CreateItemCommand("Lamp", "Lighting");
        mockMediator.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new Item { Name = "Lamp", Category = "Lighting" });

        var controller = new ItemsController(mockMediator.Object);

        // Act
        var result = await controller.Create(command);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }
}