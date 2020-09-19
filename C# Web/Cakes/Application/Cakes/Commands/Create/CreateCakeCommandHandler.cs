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

        public CreateCakeCommandHandler(IWebsiteDbContext context)
        {
            _context = context;
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
