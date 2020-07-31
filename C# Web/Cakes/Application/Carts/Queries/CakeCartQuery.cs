namespace Application.Cart.Queries
{
    using MediatR;

    public class CakeCartQuery : IRequest<CakeCartListViewModel>
    {
        public int Id { get; set; }
    }
}
