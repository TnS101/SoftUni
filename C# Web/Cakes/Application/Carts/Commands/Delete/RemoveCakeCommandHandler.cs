namespace Application.Carts.Commands.Delete
{
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveCakeCommandHandler : IRequestHandler<RemoveCakeCommand>
    {
        private readonly IWebsiteDbContext context;

        public RemoveCakeCommandHandler(IWebsiteDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(RemoveCakeCommand request, CancellationToken cancellationToken)
        {
            var cake = await context.ShoppingCarts.FirstOrDefaultAsync(s => s.CustomerId == request.CustomerId && s.CakeId == request.CakeId);

            this.context.ShoppingCarts.Remove(cake);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
