namespace Application.Cakes.Commands.Delete
{
    using Domain.Entities;
    using MediatR;

    public class BuyCakeCommand : IRequest
    {
        public decimal Check { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public Customer Customer { get; set; }
    }
}
