using System;
using System.Net;
using Core;
using Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UseCases.Events.DTOs;
using SQLitePCL;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace UseCases.Events.Queries;

public class GetEventDetails
{
    public class Query: IRequest<Result<EventDto>>
    {
        public required string Id { get; set;}
    };
    public class Handler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<Query, Result<EventDto>>
    {
        public  async Task<Result<EventDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var _event =  await context.Events.ProjectTo<EventDto>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x=>x.Id == request.Id, cancellationToken);
                if (_event == null) return Result<EventDto>.Failuire("Event not found", 404);

                var eventRes = mapper.Map<EventDto>(_event);

                return Result<EventDto>.Success(eventRes);
        }
    }
}