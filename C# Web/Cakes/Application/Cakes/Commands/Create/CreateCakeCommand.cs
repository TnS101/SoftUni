namespace Application.Cakes.Commands.Create
{
    using MediatR;

    public class CreateCakeCommand : IRequest
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
    }
}
