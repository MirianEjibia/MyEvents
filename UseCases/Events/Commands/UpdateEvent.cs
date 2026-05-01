
using System;
using AutoMapper;
using Core;
using Infrastructure;
using MediatR;

namespace   UseCases.Events.Commands;
public class UpdateEvent 
{ 
    public class Command: IRequest
    {
        public required Event Event { get; set;}
    }

    public class Handler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
           var _event = await context.Events.FindAsync([request.Event.Id], cancellationToken) ?? throw new Exception("Event not fount");
           mapper.Map(request.Event, _event);
           await context.SaveChangesAsync(cancellationToken);
        }
    }

}