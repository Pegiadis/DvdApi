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
            new Actor { ActorId = 1, },
            new Actor { ActorId = 2, }
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
        var actor = new Actor { ActorId = 1, };
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

    [Fact]
    public async Task PostActor_ReturnsCreatedAtAction()
    {
        // Arrange
        var actor = new Actor { ActorId = 1, };
        _mockActorService.Setup(s => s.AddActorAsync(actor)).ReturnsAsync(actor);

        // Act
        var result = await _controller.CreateActor(actor);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnValue = Assert.IsType<Actor>(createdAtActionResult.Value);
        Assert.Equal(1, returnValue.ActorId);
    }
}