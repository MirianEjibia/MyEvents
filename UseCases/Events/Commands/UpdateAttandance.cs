using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using UseCases.Interfaces;

namespace UseCases.Events.Commands
{
    public class UpdateAttandance
    {
        public class Command: IRequest<Result<Unit>>
        {
            public required string Id { get; set; }
        }
        public class Handler(ApplicationDbContext applicationDbContext, IUserAccessor userAccessor) 
            : IRequestHandler<Command, Result<Unit>>
        {
            public async Task<Result<Unit>> Handle(Command command, CancellationToken cancellationToken)
            {
                var _event = await applicationDbContext.Events
                    .Include(e=>e.Participants)
                    .ThenInclude(x=>x.User)
                    .FirstOrDefaultAsync(e => e.Id == command.Id, cancellationToken);

                var userId = userAccessor.GetUserId();
                var participant = _event.Participants.FirstOrDefault(e => e.UserId == userId);

                if(participant != null)
                {
                    if(participant.IsHost) _event.IsCancelled = !_event.IsCancelled;
                    else _event.Participants.Remove(participant);
                }
                else
                {
                    _event.Participants.Add(new EventParticipant
                    {
                       UserId  =  userId,
                       EventId = _event.Id,
                       IsHost = false
                    });
                }
                var res = await applicationDbContext.SaveChangesAsync(cancellationToken) > 0;
                return res ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failuire("Problem Updating DB", 400);
            }

        }
    }
}