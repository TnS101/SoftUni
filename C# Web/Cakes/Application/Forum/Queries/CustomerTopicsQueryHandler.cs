namespace Application.Forum.Queries
{
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class CustomerTopicsQueryHandler : IRequestHandler<CustomerTopicsQuery, CustomerTopicsListViewModel>
    {
        private readonly IWebsiteDbContext _context;
        private readonly IMapper _mapper;

        public CustomerTopicsQueryHandler(IWebsiteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerTopicsListViewModel> Handle(CustomerTopicsQuery request, CancellationToken cancellationToken)
        {
            return new CustomerTopicsListViewModel
            {
                Topics = await _context.Topics.Where(t => t.CustomerId == request.Id).ProjectTo<CustomerTopicViewModel>(_mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
