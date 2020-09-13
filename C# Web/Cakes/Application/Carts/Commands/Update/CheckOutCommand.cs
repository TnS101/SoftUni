namespace Application.Carts.Commands.Delete
{
    using MediatR;

    public class CheckOutCommand : IRequest
    {
        public string CustomerId { get; set; }
    }
}
