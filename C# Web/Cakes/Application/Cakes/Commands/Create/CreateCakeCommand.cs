namespace Application.Cakes.Commands.Create
{
    using MediatR;

    public class CreateCakeCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public int ShoppingCartId { get; set; }
    }
}
