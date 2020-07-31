namespace Application.Comments.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;

    public class ComentLikeCommandHandler : IRequestHandler<CommentLikeCommand>
    {
        private readonly IWebsiteDbContext _context;

        public ComentLikeCommandHandler(IWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CommentLikeCommand request, CancellationToken cancellationToken)
        {
            Comment comment = await _context.Comments.FindAsync(request.Id);

            comment.Likes++;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
