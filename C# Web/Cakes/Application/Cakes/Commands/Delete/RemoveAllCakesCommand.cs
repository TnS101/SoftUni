namespace Application.Cakes.Commands.Delete
{
    using Domain.Entities;
    using MediatR;

    public class RemoveAllCakesCommand : IRequest
    {
        public int CustomerId { get; set; }
    }
}
