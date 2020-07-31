namespace Application.Customer.Queries
{
    using MediatR;

    public class CustomerBalanceQuery : IRequest<decimal>
    {
        public int Id { get; set; }

        public decimal Balance { get; set; }
    }
}
