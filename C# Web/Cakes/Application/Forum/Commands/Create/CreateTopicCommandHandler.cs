namespace Application.Forum.Commands.Create
{
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand>
    {
        private readonly IWebsiteDbContext _context;

        public CreateTopicCommandHandler(IWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            _context.Topics.Add(new Topic
            {
                Name = request.Name,
                Category = request.Category,
                Content = request.Content,
                CustomerId = request.CustomerId,
                Comments = new List<Comment>(),
                SubmitTime = DateTime.UtcNow
            });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
