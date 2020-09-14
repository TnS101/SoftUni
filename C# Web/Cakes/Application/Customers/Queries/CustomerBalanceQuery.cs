namespace Application.Customer.Queries
{
    using MediatR;

    public class CustomerBalanceQuery : IRequest<double>
    {
        public string Id { get; set; }
    }
}
