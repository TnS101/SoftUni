namespace Application.Carts.Commands.Delete
{
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ClearCartCommandHandler : IRequestHandler<ClearCartCommand>
    {
        private readonly IWebsiteDbContext context;

        public ClearCartCommandHandler(IWebsiteDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            var cakes = await this.context.ShoppingCarts.Where(s => s.CustomerId == request.CustomerId).ToArrayAsync();

            this.context.ShoppingCarts.RemoveRange(cakes);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
