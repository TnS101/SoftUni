namespace Application.Cakes.Commands.Delete
{
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class BuyCakeCommandHandler : IRequestHandler<BuyCakeCommand>
    {
        private readonly IWebsiteDbContext _context;

        public BuyCakeCommandHandler(IWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(BuyCakeCommand request, CancellationToken cancellationToken)
        {
            foreach (var cake in request.ShoppingCart.Cakes.Where(c => c.ShoppingCart.CustomerId == request.Customer.Id))
            {
                _context.Cakes.Remove(cake);
            }

            request.Customer.Balance -= request.Check;

            _context.Orders.Add(new Order
            {
                ShoppingCart = request.ShoppingCart,
                Check = request.Check
            });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
