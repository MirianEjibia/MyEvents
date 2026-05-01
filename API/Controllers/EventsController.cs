using System;
using System.Collections.Generic;
using Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UseCases.Events.Commands;
using UseCases.Events.Queries;
namespace API.Controllers;

public class EventsController ( IMediator mediator): BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Event>>> GetEvents()
    {
        return await mediator.Send(new GetEvents.Query());
    } 

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEventDetails(string id)
    {
        return await mediator.Send(new GetEventDetails.Query{Id= id});
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateEvent(Event _event)
    {
        return await mediator.Send(new CreateEvent.Command{Event= _event});
    }

    [HttpPut]
    public async Task<ActionResult> UpdateEvent(Event _event)
    {
        await mediator.Send(new UpdateEvent.Command{Event= _event});
        return NoContent();
    }
}