namespace Application.Forum.Commands.Update
{
    using Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class LikeTopicCommandHandler : IRequestHandler<LikeTopicCommand>
    {
        private readonly IWebsiteDbContext _context;

        public LikeTopicCommandHandler(IWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(LikeTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = await _context.Topics.FindAsync(request.Id);

            topic.Likes++;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
