namespace Application.Forum.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;

    public class EditTopicCommandHandler : IRequestHandler<EditTopicCommand>
    {
        private readonly IWebsiteDbContext _context;

        public EditTopicCommandHandler(IWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditTopicCommand request, CancellationToken cancellationToken)
        {
            Topic topic = await _context.Topics.FindAsync(request.Id);

            if (request.Name != null)
            {
                topic.Name = request.Name;
            }
            if (request.Category != null)
            {
                topic.Category = request.Category;
            }
            if (request.Content != null)
            {
                topic.Content = request.Content;
            }

            _context.Topics.Update(topic);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
