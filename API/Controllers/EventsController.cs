using System;
using System.Collections.Generic;
using Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UseCases.Events.Commands;
using UseCases.Events.Queries;
using UseCases.Events.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

public class EventsController ( IMediator mediator): BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<EventDto>>> GetEvents()
    {
        return await mediator.Send(new GetEvents.Query());
    } 

    [HttpGet("{id}")]
    public async Task<ActionResult<EventDto>> GetEventDetails(string id)
    {
        return ToActionResult(await mediator.Send(new GetEventDetails.Query{Id= id}));  
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateEvent(CraeteEventDto eventDto)
    {
        return ToActionResult(await mediator.Send(new CreateEvent.Command{EventDto= eventDto}));
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "IsEventHost")]
    public async Task<ActionResult<Unit>> UpdateEvent(EditEventDto _event, string id)
    { 
        _event.Id = id;
        return ToActionResult(await  mediator.Send(new UpdateEvent.Command{EventDto= _event}));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> DeleteEvent(string id)
    {
        return ToActionResult(await mediator.Send(new DeleteEvent.Command{Id= id}));
    }
    [HttpPost("{id}/attend")]
    [Authorize( Policy = "IsEventHost")]
    public async Task<ActionResult<Unit>> UpdateAttandance(string id)
    {
        return ToActionResult(await mediator.Send(new UpdateAttandance.Command{Id= id}));
    }
}