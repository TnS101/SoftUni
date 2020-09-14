namespace Application.Customer.Queries
{
    using Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    public class CustomerBalanceQueryHandler : IRequestHandler<CustomerBalanceQuery, double>
    {
        private readonly IWebsiteDbContext _context;
        public CustomerBalanceQueryHandler(IWebsiteDbContext context)
        {
            _context = context;
        }
        public async Task<double> Handle(CustomerBalanceQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.Id);

            return customer.Balance;
        }
    }
}
