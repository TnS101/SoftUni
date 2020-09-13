namespace Application.Carts.Commands.Delete
{
    using MediatR;

    public class ClearCartCommand : IRequest
    {
        public string CustomerId { get; set; }
    }
}
