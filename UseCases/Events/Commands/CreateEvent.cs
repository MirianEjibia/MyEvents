
using System;
using Core;
using Infrastructure;
using MediatR;

namespace   UseCases.Events.Commands;
public class CreateEvent 
{
    public class Command: IRequest<string>
    {
        public required Event Event { get; set;}
    }

    public class Handler(ApplicationDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Events.Add(request.Event);
            context.SaveChanges();
            return request.Event.Id;
        }
    }

}