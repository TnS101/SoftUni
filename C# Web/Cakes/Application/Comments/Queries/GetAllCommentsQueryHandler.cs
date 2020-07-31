namespace Application.Comments.Queries
{
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, CommentsListViewModel>
    {
        private readonly IWebsiteDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCommentsQueryHandler(IWebsiteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentsListViewModel> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            return new CommentsListViewModel
            {
                Comments = await _context.Comments.Where(c => c.TopicId == request.TopicId).ProjectTo<CommentsViewModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
