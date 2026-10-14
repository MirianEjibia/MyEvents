
using System;
using AutoMapper;
using Core;
using FluentValidation;
using Persistence;
using MediatR;
using UseCases.Events.DTOs;
using UseCases.Interfaces;

namespace   UseCases.Events.Commands;
public class CreateEvent 
{
    public class Command: IRequest<Result<string>>
    {
        public required CraeteEventDto EventDto { get; set;}
    }

    public class Handler(ApplicationDbContext context, IMapper mapper, IUserAccessor userAccessor) : IRequestHandler<Command, Result<string>>
    {
        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await userAccessor.GetUserAsync();
            var _event = mapper.Map<Event>(request.EventDto);

            var eventParticipant = new EventParticipant
            {
                UserId = user.Id,
                EventId = _event.Id,
                IsHost = true
            };
            _event.Participants.Add(eventParticipant);
            context.Events.Add(_event);
            var res = await context.SaveChangesAsync(cancellationToken) > 0;
                if(!res) return Result<String>.Failuire($"Failed to add  Event with id ${_event.Id}", 400);
            return Result<string>.Success(_event.Id);
        }
    }

}