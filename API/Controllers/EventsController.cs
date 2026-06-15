using System;
using System.Collections.Generic;
using Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UseCases.Events.Commands;
using UseCases.Events.Queries;
using UseCases.Events.DTOs;

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
        return ToActionResult(await mediator.Send(new GetEventDetails.Query{Id= id}));  
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateEvent(CraeteEventDto eventDto)
    {
        return ToActionResult(await mediator.Send(new CreateEvent.Command{EventDto= eventDto}));
    }

    [HttpPut]
    public async Task<ActionResult<Unit>> UpdateEvent(Event _event)
    {
        return ToActionResult(await  mediator.Send(new UpdateEvent.Command{Event= _event}));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> DeleteEvent(string id)
    {
        return ToActionResult(await mediator.Send(new DeleteEvent.Command{Id= id}));
    }
}