namespace Application.Forum.Queries
{
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllTopicsQueryHandler : IRequestHandler<GetAllTopicsQuery, TopicListViewModel>
    {
        private readonly IWebsiteDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTopicsQueryHandler(IWebsiteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TopicListViewModel> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
        {
            var topics = new TopicListViewModel
            {
                Topics = await _context.Topics.Select(t => new TopicViewModel
                {
                    Name = t.Name,
                    Category = t.Category,
                    Content = t.Content,
                    Likes = t.Likes,
                    SubmitTime = t.SubmitTime,
                    CustomerId = t.CustomerId,
                    CommentCount = t.Comments.Count,
                    CustomerName = t.Customer.Name

                }).ToListAsync()
            };

            if (request.Order == "none")
            {
                return topics;
            }
            else if (request.Order == "popular")
            {
                topics.Topics.OrderByDescending(t => t.Likes);
                return topics;
            }
            else
            {
                topics.Topics.OrderByDescending(t => t.SubmitTime);
                return topics;
            }
        }
    }
}
