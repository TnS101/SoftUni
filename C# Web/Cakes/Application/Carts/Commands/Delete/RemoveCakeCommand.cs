namespace Application.Carts.Commands.Delete
{
    using MediatR;

    public class RemoveCakeCommand : IRequest
    {
        public int CakeId { get; set; }

        public string CustomerId { get; set; }
    }
}
