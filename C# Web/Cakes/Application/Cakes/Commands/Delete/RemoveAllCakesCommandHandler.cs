namespace Application.Cakes.Commands.Delete
{
    using Application.Common.Interfaces;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveAllCakesCommandHandler : IRequestHandler<RemoveAllCakesCommand>
    {
        private readonly IWebsiteDbContext _context;

        public RemoveAllCakesCommandHandler(IWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveAllCakesCommand request, CancellationToken cancellationToken)
        {
            foreach (var cake in _context.Cakes.Where(c => c.ShoppingCart.CustomerId == request.CustomerId))
            {
                _context.Cakes.Remove(cake);
            }
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
