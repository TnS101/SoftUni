namespace Application.Cakes.Commands.Delete
{
    using Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCakeCommandHandler : IRequestHandler<DeleteCakeCommand>
    {
        private readonly IWebsiteDbContext context;
        public DeleteCakeCommandHandler(IWebsiteDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteCakeCommand request, CancellationToken cancellationToken)
        {
            var cakeToDelete = await this.context.Cakes.FindAsync(request.CakeId);

            this.context.Cakes.Remove(cakeToDelete);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
