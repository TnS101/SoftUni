namespace Application.Forum.Commands.Delete
{
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveTopicCommandHandler : IRequestHandler<RemoveTopicCommand>
    {
        private readonly IWebsiteDbContext _context;

        public RemoveTopicCommandHandler(IWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveTopicCommand request, CancellationToken cancellationToken)
        {
            Topic topic = await _context.Topics.FindAsync(request.Id);

            var comments = topic.Comments;

            foreach (var comment in comments)
            {
                foreach (var reply in _context.Replies.Where(r => r.CommentId == comment.Id))
                {
                    _context.Replies.Remove(reply);
                }
            }

            _context.Comments.RemoveRange(comments);

            _context.Topics.Remove(topic);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
