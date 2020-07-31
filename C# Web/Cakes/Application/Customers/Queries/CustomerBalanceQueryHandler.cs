namespace Application.Customer.Queries
{
    using Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    public class CustomerBalanceQueryHandler : IRequestHandler<CustomerBalanceQuery, decimal>
    {
        private readonly IWebsiteDbContext _context;
        public CustomerBalanceQueryHandler(IWebsiteDbContext context)
        {
            _context = context;
        }
        public async Task<decimal> Handle(CustomerBalanceQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.Id);
            request.Balance = customer.Balance;

            return request.Balance;
        }
    }
}
