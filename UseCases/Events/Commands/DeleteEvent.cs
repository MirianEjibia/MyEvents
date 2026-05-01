using Infrastructure;
using MediatR;

namespace UseCases.Events.Commands;

public class DeleteEvent
{
    public class Command: IRequest
    {
        public required string Id { get; set;}
    }

    public class Handler(ApplicationDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var _event = await context.Events.FindAsync( request.Id, cancellationToken ) ?? throw new Exception("Event does not exists");
            context.Remove(_event);
            context.SaveChanges();  
        }
    }
}