namespace Application.Comments.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using MediatR;

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IWebsiteDbContext _context;

        public DeleteCommentCommandHandler(IWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var replies = _context.Replies.Where(r => r.CommentId == request.Id);
            var comment = await _context.Comments.FindAsync(request.Id);

            _context.Replies.RemoveRange(replies);
            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
