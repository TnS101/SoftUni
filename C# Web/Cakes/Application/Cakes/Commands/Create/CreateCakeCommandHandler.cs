namespace Application.Cakes.Commands.Create
{
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;
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
            this._context.Cakes.Add(new Cake
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                ImageURL = request.ImageURL,
            });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
