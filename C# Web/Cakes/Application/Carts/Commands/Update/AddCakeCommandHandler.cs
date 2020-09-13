namespace Application.Carts.Commands.Update
{
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddCakeCommandHandler : IRequestHandler<AddCakeCommand>
    {
        private readonly IWebsiteDbContext context;
        public AddCakeCommandHandler(IWebsiteDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(AddCakeCommand request, CancellationToken cancellationToken)
        {
            var cart = await this.context.ShoppingCarts.FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId && c.CakeId == request.CakeId);

            if (cart != null)
            {
                cart.Count++;
            }
            else
            {
                this.context.ShoppingCarts.Add(new ShoppingCart
                {
                    CustomerId = request.CustomerId,
                    CakeId = request.CakeId
                });
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
