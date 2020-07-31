namespace Application.Cakes.Commands.Create
{
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCakeCommandHandler : IRequestHandler<CreateCakeCommand>
    {
        private readonly IWebsiteDbContext _context;
        private readonly Customer customer;

        public CreateCakeCommandHandler(IWebsiteDbContext context, Customer customer)
        {
            _context = context;
            this.customer = customer;
        }

        public async Task<Unit> Handle(CreateCakeCommand request, CancellationToken cancellationToken)
        {
            var cake = new Cake
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                ImageURL = request.ImageURL,
                ShoppingCartId = request.ShoppingCartId
            };

            _context.ShoppingCarts.FirstOrDefault(s => s.CustomerId == customer.Id).Cakes.Add(cake);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
