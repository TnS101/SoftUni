namespace Application.Cart.Queries
{
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    public class CakeCartQueryHandler : IRequestHandler<CakeCartQuery, CakeCartListViewModel>
    {
        private readonly IWebsiteDbContext _context;
        private readonly IMapper _mapper;
        public CakeCartQueryHandler(IWebsiteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CakeCartListViewModel> Handle(CakeCartQuery request, CancellationToken cancellationToken)
        {
            return new CakeCartListViewModel
            {
                Cakes = await _context.Cakes.Where(c => c.ShoppingCart.CustomerId == request.Id).ProjectTo<CakeCartViewModel>(_mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
