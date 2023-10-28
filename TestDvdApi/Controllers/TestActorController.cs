using DvdApi.Controllers;
using DvdApi.Models;
using DvdApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace TestDvdApi.Controllers;

public class ActorControllerTests
{
    private readonly Mock<IActorService> _mockActorService;
    private readonly ActorController _controller;

    public ActorControllerTests()
    {
        _mockActorService = new Mock<IActorService>();
        _controller = new ActorController(_mockActorService.Object);
    }

    [Fact]
    public async Task GetActors_ReturnsListOfActors()
    {
        // Arrange
        var actors = new List<Actor>
        {
            new Actor { ActorId = 1, /* other properties */ },
            new Actor { ActorId = 2, /* other properties */ }
        };

        _mockActorService.Setup(s => s.GetAllActorsAsync()).ReturnsAsync(actors);

        // Act
        var result = await _controller.GetActors();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Actor>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetActor_ReturnsActor_WhenActorExists()
    {
        // Arrange
        var actor = new Actor { ActorId = 1, /* other properties */ };
        _mockActorService.Setup(s => s.GetActorByIdAsync(1)).ReturnsAsync(actor);

        // Act
        var result = await _controller.GetActor(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Actor>(okResult.Value);
        Assert.Equal(1, returnValue.ActorId);
    }

    [Fact]
    public async Task GetActor_ReturnsNotFound_WhenActorDoesNotExist()
    {
        // Arrange
        _mockActorService.Setup(s => s.GetActorByIdAsync(1)).ReturnsAsync((Actor)null);

        // Act
        var result = await _controller.GetActor(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    // You can add more tests for the other methods following the patterns above.
}