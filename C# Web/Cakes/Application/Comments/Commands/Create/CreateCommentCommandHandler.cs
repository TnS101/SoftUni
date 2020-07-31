namespace Application.Comments.Commands.Create
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IWebsiteDbContext _context;

        public CreateCommentCommandHandler(IWebsiteDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            _context.Comments.Add(new Comment
            {
                Content = request.Content,
                Replies = new List<Reply>(),
                Likes = 0,
                SubmitTime = DateTime.UtcNow,
                TopicId = request.TopicId
            });

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
