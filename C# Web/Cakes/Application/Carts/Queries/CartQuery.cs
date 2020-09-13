namespace Application.Cart.Queries
{
    using MediatR;

    public class CartQuery : IRequest<CartListViewModel>
    {
        public string CustomerId { get; set; }
    }
}
