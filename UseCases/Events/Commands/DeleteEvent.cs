using Core;
using Infrastructure;
using MediatR;

namespace UseCases.Events.Commands;

public class DeleteEvent
{
    public class Command: IRequest<Result<Unit>>
    {
        public required string Id { get; set;}
    }

    public class Handler(ApplicationDbContext context) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var _event = await context.Events.FindAsync( request.Id, cancellationToken );
            if (_event == null) return Result<Unit>.Failuire("Failed to delete Event", 404);
            context.Remove(_event);
            context.SaveChanges();
            return Result<Unit>.Success(Unit.Value);  

        }
    }
} 