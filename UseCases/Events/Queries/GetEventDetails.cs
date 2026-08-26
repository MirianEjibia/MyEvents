using System;
using System.Net;
using Core;
using Infrastructure;
using MediatR;

namespace UseCases.Events.Queries;

public class GetEventDetails
{
    public class Query: IRequest<Result<Event>>
    {
        public required string Id { get; set;}
    };
    public class Handler(ApplicationDbContext context) : IRequestHandler<Query, Result<Event>>
    {
        public  async Task<Result<Event>> Handle(Query request, CancellationToken cancellationToken)
            {
                var _event =  await context.Events.FindAsync([request.Id], cancellationToken);
                if (_event == null) return Result<Event>.Failuire("Event not found", 404);
                return Result<Event>.Success(_event);
        }
    }
}