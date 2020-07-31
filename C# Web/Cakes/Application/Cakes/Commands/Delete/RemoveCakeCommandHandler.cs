namespace Application.Cakes.Commands.Delete
{
    using Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveCakeCommandHandler : IRequestHandler<RemoveCakeCommand>
    {
        private readonly IWebsiteDbContext _context;

        public RemoveCakeCommandHandler(IWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveCakeCommand request, CancellationToken cancellationToken)
        {
            var cake = await _context.Cakes.FindAsync(request.Id);

            _context.Cakes.Remove(cake);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
