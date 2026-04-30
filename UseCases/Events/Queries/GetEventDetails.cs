using System;
using Core;
using Infrastructure;
using MediatR;

namespace UseCases.Events.Queries;

public class GetEventDetails
{
    public class Query: IRequest<Event>
    {
        public required string Id { get; set;}
    };
    public class Handler(ApplicationDbContext context) : IRequestHandler<Query, Event>
    {
        public  async Task<Event> Handle(Query request, CancellationToken cancellationToken)
        {
            var _event =  await context.Events.FindAsync([request.Id], cancellationToken);
            if (_event == null) throw new Exception("Event not found");
            return _event;
        }
    }
}