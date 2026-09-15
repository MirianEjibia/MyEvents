using API.Controllers;
using Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UseCases.Events.Queries;

namespace API.Tests;

public class EventsControllerTests
{
    private readonly Mock<IMediator> _mediator = new();
    private readonly EventsController _sut;

    public EventsControllerTests()
    {
        // "sut" = System Under Test. The controller is the thing we're testing;
        // IMediator is mocked so no real handler, DB, etc. ever runs.
        _sut = new EventsController(_mediator.Object);
    }

    [Fact]
    public async Task GetEvents_ReturnsListFromMediator()
    {
        // Arrange: teach the mock what to return when the controller sends this query.
        var events = new List<Event>
        {
            new() { Name = "Conf", Description = "desc", Country = "GE", City = "Tbilisi" }
        };
        _mediator
            .Setup(m => m.Send(It.IsAny<GetEvents.Query>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(events);

        // Act
        var result = await _sut.GetEvents();

        // Assert: controller just forwards whatever the handler returned.
        Assert.Equal(events, result.Value);
    }

    [Fact]
    public async Task GetEventDetails_EventFound_ReturnsOkWithEvent()
    {
        var found = new Event { Name = "Conf", Description = "desc", Country = "GE", City = "Tbilisi" };
        _mediator
            .Setup(m => m.Send(It.IsAny<GetEventDetails.Query>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<Event>.Success(found));

        var result = await _sut.GetEventDetails(found.Id);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(found, okResult.Value);
    }

    [Fact]
    public async Task GetEventDetails_EventMissing_ReturnsNotFound()
    {
        _mediator
            .Setup(m => m.Send(It.IsAny<GetEventDetails.Query>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<Event>.Failuire("Event not found", 404));

        var result = await _sut.GetEventDetails("missing-id");

        Assert.IsType<NotFoundResult>(result.Result);
    }
}
