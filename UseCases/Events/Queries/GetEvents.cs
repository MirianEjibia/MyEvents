using System;
using Core;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UseCases.Events.Queries;

public class GetEvents
{
    public class Query: IRequest<List<Event>> {};
    public class Handler(ApplicationDbContext context): IRequestHandler<Query, List<Event>>
    {
        public async Task<List<Event>> Handle(Query request, CancellationToken cancellationToken)
        { 
            return await context.Events.ToListAsync(cancellationToken);
        }
    }
}