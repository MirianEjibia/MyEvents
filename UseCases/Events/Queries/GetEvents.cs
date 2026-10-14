using System;
using Core;
using Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using UseCases.Events.DTOs;
using AutoMapper;

namespace UseCases.Events.Queries;

public class GetEvents
{
    public class Query: IRequest<List<EventDto>> {};
    public class Handler(ApplicationDbContext context, IMapper mapper): IRequestHandler<Query, List<EventDto>>
    {
        public async Task<List<EventDto>> Handle(Query request, CancellationToken cancellationToken)
        { 
            return await context.Events.ProjectTo<EventDto>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}