namespace Application.Carts.Commands.Delete
{
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class CheckOutCommandHandler : IRequestHandler<CheckOutCommand>
    {
        private readonly IWebsiteDbContext context;

        public CheckOutCommandHandler(IWebsiteDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(CheckOutCommand request, CancellationToken cancellationToken)
        {
            var cakes = await this.context.ShoppingCarts.Where(s => s.CustomerId == request.CustomerId).Select(c => c.Cake).ToArrayAsync();

            var customer = await this.context.Customers.FindAsync(request.CustomerId);
            var check = cakes.Sum(c => c.Price);

            if (customer.Balance - check < 0)
            {
                return Unit.Value;
            }

            customer.Balance -= check;

            for (int i = 0; i < cakes.Length; i++)
            {
                var cake = cakes[i];
                var customerCake = await this.context.CustomersCakes.FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId && c.CakeId == cake.Id);

                if (customerCake != null)
                {
                    customerCake.Count++;
                }
                else
                {
                    this.context.CustomersCakes.Add(new CustomerCakes
                    {
                        CustomerId = request.CustomerId,
                        CakeId = cake.Id,
                    });
                }
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
