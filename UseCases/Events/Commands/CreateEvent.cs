
using System;
using AutoMapper;
using Core;
using FluentValidation;
using Infrastructure;
using MediatR;
using UseCases.Events.DTOs;

namespace   UseCases.Events.Commands;
public class CreateEvent 
{
    public class Command: IRequest<Result<string>>
    {
        public required CraeteEventDto EventDto { get; set;}
    }

    public class Handler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<Command, Result<string>>
    {
        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            var _event = mapper.Map<Event>(request.EventDto);
            context.Events.Add(_event);
            var res = await context.SaveChangesAsync(cancellationToken) > 0;
                if(!res) return Result<String>.Failuire($"Failed to add  Event with id ${_event.Id}", 400);
            return Result<string>.Success(_event.Id);
        }
    }

}