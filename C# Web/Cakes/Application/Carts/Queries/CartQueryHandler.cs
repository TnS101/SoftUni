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
    public class CartQueryHandler : IRequestHandler<CartQuery, CartListViewModel>
    {
        private readonly IWebsiteDbContext context;
        private readonly IMapper mapper;
        public CartQueryHandler(IWebsiteDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<CartListViewModel> Handle(CartQuery request, CancellationToken cancellationToken)
        {
            return new CartListViewModel
            {
                Cakes = await this.context.ShoppingCarts.Where(c => c.CustomerId == request.CustomerId).Select(c => c.Cake).ProjectTo<CartViewModel>(this.mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
