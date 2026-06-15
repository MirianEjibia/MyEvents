
using System;
using AutoMapper;
using Core;
using Infrastructure;
using MediatR;

namespace   UseCases.Events.Commands;
public class UpdateEvent 
{ 
    public class Command: IRequest<Result<Unit>>
    {
        public required Event Event { get; set;}
    }

    public class Handler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
           var _event = await context.Events.FindAsync([request.Event.Id], cancellationToken);
           if (_event == null) return Result<Unit>.Failuire("Event not found", 404);
           mapper.Map(request.Event, _event);
           var res =await context.SaveChangesAsync(cancellationToken);
           if(res == 0 ) return Result<Unit>.Failuire("Failed to Update Event", 400);
           return Result<Unit>.Success(Unit.Value);
        }
    }

}