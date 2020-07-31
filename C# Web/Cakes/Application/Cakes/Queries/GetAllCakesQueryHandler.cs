namespace Application.Cakes.Queries
{
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllCakesQueryHandler : IRequestHandler<GetAllCakesQuery, CakesListViewModel>
    {
        private readonly IWebsiteDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCakesQueryHandler(IWebsiteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CakesListViewModel> Handle(GetAllCakesQuery request, CancellationToken cancellationToken)
        {
            return new CakesListViewModel
            {
                Cakes = await _context.Cakes.Where(c => c.ShoppingCart == null).ProjectTo<CakesFullViewModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
