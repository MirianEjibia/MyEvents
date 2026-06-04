
using System;
using AutoMapper;
using Core;
using Infrastructure;
using MediatR;
using UseCases.Events.DTOs;

namespace   UseCases.Events.Commands;
public class CreateEvent 
{
    public class Command: IRequest<string>
    {
        public required CraeteEventDto EventDto { get; set;}
    }

    public class Handler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var _event = mapper.Map<Event>(request.EventDto);
            context.Events.Add(_event);
            context.SaveChanges();
            return _event.Id;
        }
    }

}