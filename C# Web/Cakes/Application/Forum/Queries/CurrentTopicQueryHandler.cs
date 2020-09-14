namespace Application.Forum.Queries
{
    using Application.Common.Interfaces;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class CurrentTopicQueryHandler : IRequestHandler<CurrentTopicQuery, CurrentTopicViewModel>
    {
        private readonly IWebsiteDbContext _context;
        public CurrentTopicQueryHandler(IWebsiteDbContext context)
        {
            _context = context;
        }
        public async Task<CurrentTopicViewModel> Handle(CurrentTopicQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.Id);
            var topic = _context.Topics.FirstOrDefault(t => t.CustomerId == customer.Id);

            return new CurrentTopicViewModel
            {
                Name = topic.Name,
                Content = topic.Name,
                CustomerName = customer.UserName,
                Category = topic.Category,
                Comments = (List<CurrentTopicCommentViewModel>)topic.Comments
            };
        }
    }
}
